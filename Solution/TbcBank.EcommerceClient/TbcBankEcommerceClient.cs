using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TbcBank.EcommerceClient
{
    public class TbcBankEcommerceClient
    {
        private readonly TbcBankEcommerceClientOptions _options;

        public TbcBankEcommerceClient(TbcBankEcommerceClientOptions options)
        {
            options.Validate();
            _options = options;
        }

        /// <summary>
        /// Command - V
        /// </summary>
        /// <param name="amount">Amount in fractional units (i.e. Cents, Tetris)</param>
        /// <returns></returns>
        public async Task<RegisterTransactionResponse> RegisterTransactionAsync(int amount, CurrencyCode currency, string clientIpAddress, string description, string language = PaymentUiLanguage.Georgian, string merchantTransactionId = null)
        {
            var requestParameters = new Dictionary<string, string>()
            {
                {"command", "v"},
                {"msg_type", "SMS"},
                {"amount", amount.ToString()},
                {"currency", ((int)currency).ToString() },
                {"client_ip_addr", clientIpAddress},
                {"description", description},
                {"language", language},
                { "mrch_transaction_id", merchantTransactionId }
            };

            return new RegisterTransactionResponse(await MakePostRequestAsync(requestParameters));
        }
        /// <summary>
        /// Command - Z
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="currency"></param>
        /// <param name="clientIpAddress"></param>
        /// <param name="description"></param>
        /// <param name="recurringPaymentUniqueId"></param>
        /// <param name="expiryDate"></param>
        /// <param name="language"></param>
        /// <param name="merchantTransactionId"></param>
        /// <returns></returns>
        public async Task<RegisterTransactionResponse> RegisterTransactionAndGetReoccuringPaymentIdAsync(int amount, CurrencyCode currency, string clientIpAddress, string description, string recurringPaymentUniqueId, DateTimeOffset? expiryDate = null, string language = PaymentUiLanguage.Georgian, string merchantTransactionId = null)
        {
            expiryDate = expiryDate ?? GetDefaultExpiryDate();

            var requestParameters = new Dictionary<string, string>()
            {
                {"command", "z"},
                {"msg_type", "SMS"},
                {"amount", amount.ToString()},
                {"currency", ((int)currency).ToString() },
                {"client_ip_addr", clientIpAddress},
                {"description", description},
                {"language", language},
                {"biller_client_id", recurringPaymentUniqueId},
                {"perspayee_expiry", expiryDate.Value.ToString("MMyy")},
                { "perspayee_gen", "1"},
                { "mrch_transaction_id", merchantTransactionId }
                //"&biller", "{transactionId}"},
            };

            return new RegisterTransactionResponse(await MakePostRequestAsync(requestParameters));
        }

        //public Task GetReoccuringPaymentIdAsync(int amount, CurrencyCode currency, string clientIpAddress, string description, string recurringPaymentUniqueId, DateTimeOffset? expiryDate, string language = PaymentUiLanguage.Georgian, string merchantTransactionId = null)
        //{
        //    expiryDate = expiryDate ?? GetDefaultExpiryDate();
        //    throw new NotImplementedException();

        //    //command=p&amount=0&currency=<currency>&client_ip_addr=<ip>&desciption=<desc>&language=<language>&msg_type=AUTH&biller_client_id=<recc_pmnt_id>&perspayee_expiry=<expiry>&perspayee_gen=1

        //    //Result
        //    //TRANSACTION_ID: <trans_id>
        //    //In case of an error, the returned string of symbols begins with ‘error:‘.
        //}

        /// <summary>
        /// Command  - E
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="currency"></param>
        /// <param name="clientIpAddress"></param>
        /// <param name="description"></param>
        /// <param name="billerClientId"></param>
        /// <param name="language"></param>
        /// <param name="merchantTransactionId"></param>
        /// <returns></returns>
        public async Task<ExecuteReoccurringTransactionResponse> ExecuteReoccurringTransactionAsync(int amount, CurrencyCode currency, string clientIpAddress, string description, string billerClientId, string language = PaymentUiLanguage.Georgian, string merchantTransactionId = null)
        {
            var requestParameters = new Dictionary<string, string>()
            {
                { "command", "e"},
                { "amount", amount.ToString()},
                { "currency", ((int)currency).ToString() },
                { "client_ip_addr", clientIpAddress},
                { "description", description},
                { "desc", description},
                { "language", language},
                { "biller_client_id", billerClientId},
                { "mrch_transaction_id", merchantTransactionId }
            };

            return new ExecuteReoccurringTransactionResponse(await MakePostRequestAsync(requestParameters));
        }
        /// <summary>
        /// Command - A
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="currency"></param>
        /// <param name="clientIpAddress"></param>
        /// <param name="description"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<RegisterTransactionResponse> RegisterPreAuthorizationAsync(int amount, CurrencyCode currency, string clientIpAddress, string description, string language = PaymentUiLanguage.Georgian, string merchantTransactionId = null)
        {
            var requestParameters = new Dictionary<string, string>()
            {
                { "command", "a"},
                { "msg_type", "DMS"},
                { "amount", amount.ToString()},
                { "currency", ((int)currency).ToString() },
                { "client_ip_addr", clientIpAddress},
                { "description", description},
                { "language", language},
                { "mrch_transaction_id", merchantTransactionId }
            };

            return new RegisterTransactionResponse(await MakePostRequestAsync(requestParameters));
        }
        /// <summary>
        /// Command - T
        /// </summary>
        /// <param name="transactionId"></param>
        /// <param name="amount"></param>
        /// <param name="currency"></param>
        /// <param name="clientIpAddress"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public async Task<ExecutePreAuthorizationResponse> ExecutePreAuthorizationAsync(string transactionId, int amount, CurrencyCode currency, string clientIpAddress, string description)
        {
            var requestParameters = new Dictionary<string, string>()
            {
                { "command", "t"},
                { "msg_type", "DMS"},
                { "trans_id", transactionId},
                { "amount", amount.ToString()},
                { "currency", ((int)currency).ToString() },
                { "client_ip_addr", clientIpAddress},
                { "description", description},
                { "desc", description},
            };

            return new ExecutePreAuthorizationResponse(await MakePostRequestAsync(requestParameters));
        }
        /// <summary>
        /// Command - C
        /// </summary>
        /// <param name="transactionId"></param>
        /// <param name="clientIpAddress"></param>
        /// <returns></returns>
        public async Task<CheckTransactionResultResponse> CheckTransactionResultAsync(string transactionId, string clientIpAddress)
        {
            var requestParameters = new Dictionary<string, string>()
            {
                { "command", "c"},
                { "trans_id", transactionId},
                { "client_ip_addr", clientIpAddress}
            };

            return new CheckTransactionResultResponse(await MakePostRequestAsync(requestParameters));
        }
        /// <summary>
        /// Command - R
        /// </summary>
        /// <param name="transactionId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public async Task<ReverseTransactionResponse> ReverseTransactionAsync(string transactionId, int amount)
        {
            var requestParameters = new Dictionary<string, string>()
            {
                { "command", "r"},
                { "trans_id", transactionId },
                { "amount", amount.ToString() }
            };

            return new ReverseTransactionResponse(await MakePostRequestAsync(requestParameters));

            throw new NotImplementedException();
        }
        /// <summary>
        /// Command - K
        /// </summary>
        /// <param name="transactionId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public async Task<RefundTransactionResponse> RefundTransactionAsync(string transactionId, int amount)
        {
            var requestParameters = new Dictionary<string, string>()
            {
                { "command", "k"},
                { "trans_id", transactionId },
                { "amount", amount.ToString() }
            };

            return new RefundTransactionResponse(await MakePostRequestAsync(requestParameters));
        }
        /// <summary>
        /// Command - G
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="billerClientId"></param>
        /// <param name="description"></param>
        /// <param name="merchantTransactionId"></param>
        /// <returns></returns>
        public async Task<ExecuteCreditTransactionResponse> ExecuteCreditTransaction(int amount, string billerClientId, string description, string merchantTransactionId = null)
        {

            var requestParameters = new Dictionary<string, string>()
            {
                { "command", "ag"},
                { "amount", amount.ToString()},
                { "trans_id", billerClientId},
                { "mrch_transaction_id", merchantTransactionId }
            };

            return new ExecuteCreditTransactionResponse(await MakePostRequestAsync(requestParameters));
        }
        public string GetClientRedirectUrl(string transactionId)
        {
            var url = ServiceUrlBuilder.GetClientHandlerUrl(_options.Environment);
            return $"{url}?trans_id={System.Web.HttpUtility.UrlEncode(transactionId)}";
        }

        private DateTimeOffset GetDefaultExpiryDate()
        {
            return DateTimeOffset.UtcNow.Date.AddYears(10);
        }
        private async Task<HttpRequestResult> MakePostRequestAsync(IDictionary<string, string> requestParameters)
        {
            StringBuilder queryBuilder = new StringBuilder();
            foreach (var requestParameter in requestParameters)
            {
                if (requestParameter.Value == null) { continue; }
                queryBuilder.Append($"{requestParameter.Key}={Uri.EscapeDataString(requestParameter.Value)}&");
            }
            if (queryBuilder.Length > 1) { queryBuilder.Remove(queryBuilder.Length - 1, 1); }


            HttpRequestResult result = new HttpRequestResult();

            using (var handler = new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                SslProtocols = SslProtocols.Tls12,
            })
            {
                handler.ServerCertificateCustomValidationCallback = (message, certificate, chain, sslPolicyErrors) => true;

                using (var certificate = CreateCertificate())
                {
                    handler.ClientCertificates.Add(certificate);

                    using (HttpClient client = new HttpClient(handler))
                    {
                        using (var content = new StringContent(queryBuilder.ToString(), Encoding.UTF8, "application/x-www-form-urlencoded"))
                        {
                            var url = ServiceUrlBuilder.GetMerchantHandlerUrl(_options.Environment);
                            var responseMessage = await client.PostAsync(url, content);

                            result.HttpStatsCode = responseMessage.StatusCode;
                            result.Success = responseMessage.IsSuccessStatusCode;
                            result.RawResponse = await responseMessage.Content.ReadAsStringAsync();
                        }
                    }
                }
            }

            return result;
        }

        private X509Certificate2 CreateCertificate()
        {
            return _options.CertData != null
                  ? new X509Certificate2(_options.CertData, _options.CertPassword, X509KeyStorageFlags.MachineKeySet)
                  : new X509Certificate2(_options.CertPath, _options.CertPassword, X509KeyStorageFlags.MachineKeySet);
        }
    }
}
