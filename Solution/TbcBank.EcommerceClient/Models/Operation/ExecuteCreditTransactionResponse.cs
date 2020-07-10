using System;
using System.Collections.Generic;
using System.Text;

namespace TbcBank.EcommerceClient
{
    public class ExecuteCreditTransactionResponse : OperationResponse
    {
        public ExecuteCreditTransactionResponse(HttpRequestResult httpResult)
            : base(httpResult)
        {
        }

        protected override void AssignModelValues()
        {
            
        }
    }
    public class CloseBusinessDayResponse : OperationResponse
    {
        public CloseBusinessDayResponse(HttpRequestResult httpResult)
            : base(httpResult)
        {
        }

        protected override void AssignModelValues()
        {

        }
    }
}
