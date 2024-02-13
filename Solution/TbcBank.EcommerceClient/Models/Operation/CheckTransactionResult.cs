using System;

namespace TbcBank.EcommerceClient
{
    public class CheckTransactionResult : FinancialOperationResult
    {
        public string Result { get; set; }
        public string ThreeDSecureStatus { get; set; }
        public string Rrn { get; set; }
        public string ApprovalCode { get; set; }
        public string CardNumber { get; set; }
        public string ReocurringPaymentBillerClientId { get; set; }
        public DateTimeOffset? ReocurringPaymentExpiry { get; set; }
        public TransactionState State { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public CheckTransactionResult(HttpRequestResult httpResult)
            : base(httpResult)
        {
        }

        protected override void AssignModelValues()
        {
            Result = GetResponseKeyValue("RESULT");
            ResultCode = GetResponseKeyValue("RESULT_CODE");
            ThreeDSecureStatus = GetResponseKeyValue("3DSECURE");
            Rrn = GetResponseKeyValue("RRN");
            ApprovalCode = GetResponseKeyValue("APPROVAL_CODE");
            CardNumber = GetResponseKeyValue("CARD_NUMBER");
            ReocurringPaymentBillerClientId = FixBillerClientId(GetResponseKeyValue("RECC_PMNT_ID"));
            PaymentMethod = ParsePaymentMethod(GetResponseKeyValue("PAYMENT_METHOD"));

            ParseReccPmntExpiry();
            State = ParseState();
        }

        private TransactionState ParseState()
        {
            if (!String.IsNullOrWhiteSpace(ErrorMessage))
                return TransactionState.Failed;

            switch (Result)
            {
                case TransactionResultStatus.CREATED:
                case TransactionResultStatus.PENDING:
                case TransactionResultStatus.ACTIVE:
                    return TransactionState.Pending;

                case TransactionResultStatus.OK:
                case TransactionResultStatus.FINISHED:
                    return TransactionState.Succeeded;

                case TransactionResultStatus.FAILED:
                case TransactionResultStatus.DECLINED:
                case TransactionResultStatus.REVERSED:
                case TransactionResultStatus.AUTOREVERSED:
                case TransactionResultStatus.TIMEOUT:
                case TransactionResultStatus.RETURNED:
                case TransactionResultStatus.CANCELLED:
                    return TransactionState.Failed;

                default:
                    return TransactionState.Unknown;
            }
        }
        protected override bool IsFinancialOperationSuccessful()
        {
            return ResultCode?.StartsWith("0") == true;
        }
        private void ParseReccPmntExpiry()
        {
            var expiryValue = GetResponseKeyValue("RECC_PMNT_EXPIRY");
            if (expiryValue?.Length == 4)
                try
                {
                    int month = Convert.ToInt32(expiryValue.Substring(0, 2));
                    int year = Convert.ToInt32(expiryValue.Substring(2, 2)) + 2000;
                    ReocurringPaymentExpiry = new DateTimeOffset(year, month, 1, 0, 0, 0, TimeSpan.Zero)
                        .AddMonths(1)
                        .AddDays(-1);
                }
                catch
                {
                    ReocurringPaymentExpiry = null;
                }
        }
        private string FixBillerClientId(string responseBillerClientId)
        {
            return ResponseProcessingHelper.FixBillerClientIdUfcResponse(responseBillerClientId);
        }
        private PaymentMethod ParsePaymentMethod(string paymentMethod)
        {
            if (paymentMethod is null)
            {
                return PaymentMethod.Card;
            }

            switch (paymentMethod)
            {
                case TransactionPaymentMethod.GooglePay:
                    return PaymentMethod.GooglePay;

                case TransactionPaymentMethod.ApplePay:
                    return PaymentMethod.ApplePay;

                default:
                    return PaymentMethod.Unknown;
            }
        }
    }
}
