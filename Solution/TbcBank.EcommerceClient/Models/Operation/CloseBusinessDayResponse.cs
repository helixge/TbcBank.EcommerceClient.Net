namespace TbcBank.EcommerceClient
{
    public class CloseBusinessDayResponse : OperationResponse
    {
        public string Result { get; set; }
        public string ResultCode { get; set; }

        public override bool IsError => base.IsError || ResultCode != "500";

        public CloseBusinessDayResponse(HttpRequestResult httpResult)
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
