using System;
using System.Collections.Generic;
using System.Text;

namespace TbcBank.EcommerceClient
{
    public class RefundTransactionResult : FinancialOperationResult
    {
        public string Result { get; set; }

        public RefundTransactionResult(HttpRequestResult httpResult)
            : base(httpResult)
        {
        }

        protected override void AssignModelValues()
        {
            Result = GetResponseKeyValue("RESULT");
            ResultCode = GetResponseKeyValue("RESULT_CODE");
        }
        protected override bool IsFinancialOperationSuccessful()
        {
            return ResultCode?.StartsWith("0") == true;
        }
    }
}
