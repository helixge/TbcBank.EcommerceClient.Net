using System.Net.Http;

namespace TbcBank.EcommerceClient
{
    public interface IMerchantHttpClientFactory
    {
        HttpClient GetHttpClient(TbcBankEcommerceClientOptions options);
    }
}
