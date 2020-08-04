using System;
using System.Collections.Generic;
using System.Text;

namespace TbcBank.EcommerceClient
{
    public class ExecuteCreditTransactionResult : OperationResult
    {
        public ExecuteCreditTransactionResult(HttpRequestResult httpResult)
            : base(httpResult)
        {
        }

        protected override void AssignModelValues()
        {
            
        }
    }
}
