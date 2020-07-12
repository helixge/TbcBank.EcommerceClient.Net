using System;
using System.Collections.Generic;
using System.Text;

namespace TbcBank.EcommerceClient
{
    public class ReverseTransactionResponse : OperationResponse
    {
        public string Result { get; set; }
        public string ResultCode { get; set; }

        public override bool IsError => base.IsError || ResultCode != "400";

        public ReverseTransactionResponse(HttpRequestResult httpResult)
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
