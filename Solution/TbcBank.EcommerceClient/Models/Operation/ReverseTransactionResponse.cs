using System;
using System.Collections.Generic;
using System.Text;

namespace TbcBank.EcommerceClient
{
    public class ReverseTransactionResponse : FinancialOperationResponse
    {
        public string Result { get; set; }

        public ReverseTransactionResponse(HttpRequestResult httpResult)
            : base(httpResult)
        {
        }

        protected override void AssignModelValues()
        {
            Result = GetResponseKeyValue("RESULT");
            ResultCode = GetResponseKeyValue("RESULT_CODE");
        }

        protected override bool IsFinancialOperationSuccessful()
            => ResultCode == "400";
    }
}
