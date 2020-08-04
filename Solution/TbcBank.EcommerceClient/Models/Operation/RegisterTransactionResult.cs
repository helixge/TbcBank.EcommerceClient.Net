using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace TbcBank.EcommerceClient
{
    public class RegisterTransactionResult : OperationResult
    {
        public string TransactionId { get; set; }
        public string MerchantTransactionId { get; set; }

        public RegisterTransactionResult(HttpRequestResult httpResult)
            : base(httpResult)
        {
        }

        protected override void AssignModelValues()
        {
            TransactionId = GetResponseKeyValue("TRANSACTION_ID");
            MerchantTransactionId = GetResponseKeyValue("MRCH_TRANSACTION_ID");
        }
    }
}
