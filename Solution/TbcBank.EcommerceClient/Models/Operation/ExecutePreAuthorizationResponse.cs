using System;
using System.Collections.Generic;
using System.Text;

namespace TbcBank.EcommerceClient
{
    public class ExecutePreAuthorizationResponse : OperationResponse
    {
        public string Result { get; set; }
        public string ResultCode { get; set; }
        public string Rrn { get; set; }
        public string ApprovalCode { get; set; }
        public string CardNumber { get; set; }

        public ExecutePreAuthorizationResponse(HttpRequestResult httpResult)
            : base(httpResult)
        {
        }

        protected override void AssignModelValues()
        {
            Result = GetResponseKeyValue("RESULT");
            ResultCode = GetResponseKeyValue("RESULT_CODE");
            Rrn = GetResponseKeyValue("RRN");
            ApprovalCode = GetResponseKeyValue("APPROVAL_CODE");
            CardNumber = GetResponseKeyValue("CARD_NUMBER");
        }
    }
}
