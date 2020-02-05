using System;
using System.Collections.Generic;
using System.Text;

namespace TbcBank.EcommerceClient
{
    public class ExecuteReoccurringTransactionResponse : OperationResponse
    {
        public string TransactionId { get; set; }
        public string Result { get; set; }
        public string ResultCode { get; set; }
        public string Rrn { get; set; }
        public string ApprovalCode { get; set; }
        public string CardNumber { get; set; }

        public ExecuteReoccurringTransactionResponse(HttpRequestResult httpResult)
            : base(httpResult)
        {
        }

        protected override void AssignModelValues()
        {
            TransactionId = GetResponseKeyValue("TRANSACTION_ID");
            Result = GetResponseKeyValue("RESULT");
            ResultCode = GetResponseKeyValue("RESULT_CODE");
            Rrn = GetResponseKeyValue("RRN");
            ApprovalCode = GetResponseKeyValue("APPROVAL_CODE");
            CardNumber = GetResponseKeyValue("CARD_NUMBER");
        }
    }
}
