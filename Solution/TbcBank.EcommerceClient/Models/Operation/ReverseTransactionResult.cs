using System;
using System.Collections.Generic;
using System.Text;

namespace TbcBank.EcommerceClient
{
    public class ReverseTransactionResult : FinancialOperationResult
    {
        public string Result { get; set; }

        public ReverseTransactionResult(HttpRequestResult httpResult)
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
