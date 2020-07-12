using System;
using System.Collections.Generic;
using System.Text;

namespace TbcBank.EcommerceClient
{
    public class RefundTransactionResponse : OperationResponse
    {
        public string Result { get; set; }
        public string ResultCode { get; set; }

        public override bool IsError => base.IsError || ResultCode != "000";

        public RefundTransactionResponse(HttpRequestResult httpResult)
            : base(httpResult)
        {
        }

        protected override void AssignModelValues()
        {
            Result = GetResponseKeyValue("RESULT");
            ResultCode = GetResponseKeyValue("RESULT_CODE");
        }
    }
}
