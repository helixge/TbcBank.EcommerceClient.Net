namespace TbcBank.EcommerceClient
{
    public abstract class FinancialOperationResult : OperationResult
    {
        public string ResultCode { get; set; }

        public override bool IsError => base.IsError || !IsFinancialOperationSuccessful();

        protected FinancialOperationResult(HttpRequestResult httpResult)
            : base(httpResult)
        {
        }

        protected abstract bool IsFinancialOperationSuccessful();
    }
}
