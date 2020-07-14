using System;
using System.Collections.Generic;
using System.Text;

namespace TbcBank.EcommerceClient
{
    public class CheckTransactionResultResponse : OperationResponse
    {
        public string Result { get; set; }
        public string ResultCode { get; set; }
        public string ThreeDSecureStatus { get; set; }
        public string Rrn { get; set; }
        public string ApprovalCode { get; set; }
        public string CardNumber { get; set; }
        public string ReocurringPaymentBillerClientId { get; set; }
        public DateTimeOffset? ReocurringPaymentExpiry { get; set; }
        //public string MerchantTransactionId { get; set; }

        public CheckTransactionResultResponse(HttpRequestResult httpResult)
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
            ReocurringPaymentBillerClientId = GetResponseKeyValue("RECC_PMNT_ID");
            //MerchantTransactionId = GetResponseKeyValue("MRCH_TX_ID"); //MRCH_TRANSACTION_ID  -  Service does not return any of it

            ParseReccPmntExpiry();
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
    }
}
