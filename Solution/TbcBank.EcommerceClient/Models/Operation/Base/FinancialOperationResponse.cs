namespace TbcBank.EcommerceClient
{
    public abstract class FinancialOperationResponse : OperationResponse
    {
        public string ResultCode { get; set; }

        public override bool IsError => base.IsError || !IsFinancialOperationSuccessful();

        protected FinancialOperationResponse(HttpRequestResult httpResult) : base(httpResult)
        {
        }

        protected abstract bool IsFinancialOperationSuccessful();
    }
}
