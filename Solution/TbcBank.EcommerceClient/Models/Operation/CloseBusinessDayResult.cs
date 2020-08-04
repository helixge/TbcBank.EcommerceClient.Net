namespace TbcBank.EcommerceClient
{
    public class CloseBusinessDayResult : FinancialOperationResult
    {
        public string Result { get; set; }

        public override bool IsError => base.IsError || ResultCode != "500";

        public CloseBusinessDayResult(HttpRequestResult httpResult)
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
            return ResultCode == "500";
        }
    }
}
