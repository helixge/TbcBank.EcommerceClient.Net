using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TbcBank.EcommerceClient
{
    public class TbcBankEcommerceClient
    {
        private readonly IEnumerable<TbcBankEcommerceClientOptions> _optionsList;

        private TbcBankEcommerceClientOptions _activeOptions;

        public TbcBankEcommerceClient(IEnumerable<TbcBankEcommerceClientOptions> optionsList)
        {
            optionsList.Validate();
            _optionsList = optionsList;
        }

        /// <summary>
        /// Command - V
        /// </summary>
        /// <param name="amount">Amount in fractional units (i.e. Cents, Tetris)</param>
        /// <returns></returns>
        public async Task<RegisterTransactionResult> RegisterTransactionAsync(int amount, CurrencyCode currency, string clientIpAddress, string description, string language = PaymentUiLanguage.Georgian, string merchantTransactionId = null)
        {
            SetActiveOptions(currency);

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

            return new RegisterTransactionResult(await MakePostRequestAsync(requestParameters));
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
        public async Task<RegisterTransactionResult> RegisterTransactionAndGetReoccuringPaymentIdAsync(int amount, CurrencyCode currency, string clientIpAddress, string description, string recurringPaymentUniqueId, DateTimeOffset? expiryDate = null, string language = PaymentUiLanguage.Georgian, string merchantTransactionId = null)
        {
            SetActiveOptions(currency);

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
            };

            return new RegisterTransactionResult(await MakePostRequestAsync(requestParameters));
        }
        /// <summary>
        /// Command - P
        /// </summary>
        /// <param name="currency"></param>
        /// <param name="clientIpAddress"></param>
        /// <param name="description"></param>
        /// <param name="recurringPaymentUniqueId"></param>
        /// <param name="expiryDate"></param>
        /// <param name="language"></param>
        /// <param name="merchantTransactionId"></param>
        /// <returns></returns>
        public async Task<RegisterTransactionResult> RegisterTransactionAndGetReoccuringPaymentIdWithoutChargeAsync(CurrencyCode currency, string clientIpAddress, string description, string recurringPaymentUniqueId, DateTimeOffset? expiryDate = null, string language = PaymentUiLanguage.Georgian, string merchantTransactionId = null)
        {
            SetActiveOptions(currency);

            expiryDate = expiryDate ?? GetDefaultExpiryDate();

            var requestParameters = new Dictionary<string, string>()
            {
                {"command", "p"},
                {"msg_type", "AUTH"},
                {"amount", "0"},
                {"currency", ((int)currency).ToString() },
                {"client_ip_addr", clientIpAddress},
                {"description", description},
                {"language", language},
                {"biller_client_id", recurringPaymentUniqueId},
                {"perspayee_expiry", expiryDate.Value.ToString("MMyy")},
                { "perspayee_gen", "1"},
                { "mrch_transaction_id", merchantTransactionId }
            };

            return new RegisterTransactionResult(await MakePostRequestAsync(requestParameters));
        }
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
        public async Task<ExecuteReoccurringTransactionResult> ExecuteReoccurringTransactionAsync(int amount, CurrencyCode currency, string clientIpAddress, string description, string billerClientId, string language = PaymentUiLanguage.Georgian, string merchantTransactionId = null)
        {
            SetActiveOptions(currency);

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

            return new ExecuteReoccurringTransactionResult(await MakePostRequestAsync(requestParameters));
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
        public async Task<RegisterTransactionResult> RegisterPreAuthorizationAsync(int amount, CurrencyCode currency, string clientIpAddress, string description, string language = PaymentUiLanguage.Georgian, string merchantTransactionId = null)
        {
            SetActiveOptions(currency);

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

            return new RegisterTransactionResult(await MakePostRequestAsync(requestParameters));
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
        public async Task<ExecutePreAuthorizationResult> ExecutePreAuthorizationAsync(string transactionId, int amount, CurrencyCode currency, string clientIpAddress, string description)
        {
            SetActiveOptions(currency);

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

            return new ExecutePreAuthorizationResult(await MakePostRequestAsync(requestParameters));
        }
        /// <summary>
        /// Command - C
        /// </summary>
        /// <param name="transactionId"></param>
        /// <param name="clientIpAddress"></param>
        /// <returns></returns>
        public async Task<CheckTransactionResult> CheckTransactionResultAsync(string transactionId, string clientIpAddress)
        {
            var requestParameters = new Dictionary<string, string>()
            {
                { "command", "c"},
                { "trans_id", transactionId},
                { "client_ip_addr", clientIpAddress}
            };

            return new CheckTransactionResult(await MakePostRequestAsync(requestParameters));
        }
        /// <summary>
        /// Command - R
        /// </summary>
        /// <param name="transactionId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public async Task<ReverseTransactionResult> ReverseTransactionAsync(string transactionId, int amount)
        {
            var requestParameters = new Dictionary<string, string>()
            {
                { "command", "r"},
                { "trans_id", transactionId },
                { "amount", amount.ToString() }
            };

            return new ReverseTransactionResult(await MakePostRequestAsync(requestParameters));

            throw new NotImplementedException();
        }
        /// <summary>
        /// Command - K
        /// </summary>
        /// <param name="transactionId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public async Task<RefundTransactionResult> RefundTransactionAsync(string transactionId, int amount)
        {
            var requestParameters = new Dictionary<string, string>()
            {
                { "command", "k"},
                { "trans_id", transactionId },
                { "amount", amount.ToString() }
            };

            return new RefundTransactionResult(await MakePostRequestAsync(requestParameters));
        }
        /// <summary>
        /// Command - G
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="billerClientId"></param>
        /// <param name="description"></param>
        /// <param name="merchantTransactionId"></param>
        /// <returns></returns>
        public async Task<ExecuteCreditTransactionResult> ExecuteCreditTransactionAsync(int amount, string billerClientId, string description, string merchantTransactionId = null)
        {

            var requestParameters = new Dictionary<string, string>()
            {
                { "command", "ag"},
                { "amount", amount.ToString()},
                { "trans_id", billerClientId},
                { "description", description},
                { "mrch_transaction_id", merchantTransactionId }
            };

            return new ExecuteCreditTransactionResult(await MakePostRequestAsync(requestParameters));
        }
        /// <summary>
        /// Command - B
        /// </summary>
        /// <returns></returns>
        public async Task<CloseBusinessDayResult> CloseBusinessDayAsync()
        {
            var requestParameters = new Dictionary<string, string>()
            {
                { "command", "b"},
            };

            return new CloseBusinessDayResult(await MakePostRequestAsync(requestParameters));
        }
        /// <summary>
        /// Gets redirect URL where the client should be navigated to enter card details
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        public string GetClientRedirectUrl(string transactionId)
        {
            SetActiveOptions();
            var url = ServiceUrlBuilderHelper.GetClientHandlerUrl(_activeOptions.Environment);
            return $"{url}?trans_id={System.Web.HttpUtility.UrlEncode(transactionId)}";
        }
        /// <summary>
        /// Sets the specific merchant to use when communicating with the Bank.
        /// If you use multiple mechants you can explicitly call this method to set a specific method.
        /// Otherwise the best option will be automatically selected based on the operation currency
        /// </summary>
        public void SelectMerchant(string merchantId)
        {
            var merchantOptions = _optionsList
                .FirstOrDefault(o => o.MerchantId == merchantId);

            if (merchantOptions == null)
                throw new TbcBankEcommerceClientConfigurationException($"Merchant not found with the id '{merchantId}'");

            _activeOptions = merchantOptions;
        }
        /// <summary>
        /// Sets the specific merchant to use when communicating with the Bank.
        /// If you use multiple mechants you can explicitly call this method to set a specific method.
        /// Otherwise the best option will be automatically selected based on the operation currency
        /// </summary>
        public void SelectMerchant(Func<TbcBankEcommerceClientOptions, bool> predicate)
        {
            var merchantOptions = _optionsList
                .FirstOrDefault(predicate);

            if (merchantOptions == null)
                throw new TbcBankEcommerceClientConfigurationException($"Merchant not found using the predicate");

            _activeOptions = merchantOptions;
        }

        private void SetActiveOptions(CurrencyCode? currencyCode = null)
        {
            if (_activeOptions != null)
                return;

            if (currencyCode.HasValue)
                _activeOptions = _optionsList
                    .FirstOrDefault(o => o.Currencies.Contains(currencyCode.Value));

            if (_activeOptions == null)
                _activeOptions = _optionsList
                    .FirstOrDefault();

            if (_activeOptions == null)
                throw new TbcBankEcommerceClientConfigurationException("Failed to select active options");

        }
        private DateTimeOffset GetDefaultExpiryDate()
        {
            return DateTimeOffset.UtcNow.Date.AddYears(10);
        }
        private async Task<HttpRequestResult> MakePostRequestAsync(IDictionary<string, string> requestParameters)
        {
            SetActiveOptions();

            if (requestParameters is null)
                throw new ArgumentNullException(nameof(requestParameters));

            StringBuilder queryBuilder = new StringBuilder();
            foreach (var requestParameter in requestParameters)
            {
                if (requestParameter.Value == null)
                    continue;

                queryBuilder.Append($"{requestParameter.Key}={Uri.EscapeDataString(requestParameter.Value)}&");
            }

            if (queryBuilder.Length > 1)
                queryBuilder.Remove(queryBuilder.Length - 1, 1);


            HttpRequestResult result = new HttpRequestResult()
            {
                RequestUrl = ServiceUrlBuilderHelper.GetMerchantHandlerUrl(_activeOptions.Environment),
                RequestQuery = queryBuilder.ToString()
            };

            try
            {
                using var handler = GetHttpClientHandler();

                handler.ServerCertificateCustomValidationCallback = (message, certificate, chain, sslPolicyErrors) => true;

                using var certificate = CreateCertificate();

                handler.ClientCertificates.Add(certificate);

                using var client = new HttpClient(handler);

                using var content = new StringContent(result.RequestQuery, Encoding.UTF8, "application/x-www-form-urlencoded");

                var responseMessage = await client.PostAsync(result.RequestUrl, content);

                result.HttpStatsCode = responseMessage.StatusCode;
                result.Success = responseMessage.IsSuccessStatusCode;
                result.RawResponse = await responseMessage.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Exception = ex;
            }

            return result;
        }
        private HttpClientHandler GetHttpClientHandler()
        {
            SetActiveOptions();

            if (_activeOptions.Environment == TbcEnvironment.LegacyProduction)
                return new HttpClientHandler
                {
                    ClientCertificateOptions = ClientCertificateOption.Manual
                };

            return new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                SslProtocols = SslProtocols.Tls12,
            };
        }
        private X509Certificate2 CreateCertificate()
        {
            try
            {
                SetActiveOptions();

                return _activeOptions.CertData != null
                      ? new X509Certificate2(_activeOptions.CertData, _activeOptions.CertPassword, X509KeyStorageFlags.MachineKeySet)
                      : new X509Certificate2(_activeOptions.CertPath, _activeOptions.CertPassword, X509KeyStorageFlags.MachineKeySet);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create X509Certificate2", ex);
            }
        }
    }
}
