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
        private readonly IMerchantHttpClientFactory _merchantHttpClientFactory;
        private readonly IEnumerable<TbcBankEcommerceClientOptions> _optionsList;
        private TbcBankEcommerceClientOptions _manuallySetActiveOptions;

        /// <summary>
        /// Constructor used by ASP.NET Core dependency injection
        /// </summary>
        /// <param name="optionsList"></param>
        public TbcBankEcommerceClient(
            IMerchantHttpClientFactory merchantHttpClientFactory,
            IEnumerable<TbcBankEcommerceClientOptions> optionsList)
        {
            optionsList.Validate();
            _merchantHttpClientFactory = merchantHttpClientFactory;
            _optionsList = optionsList;
        }

        /// <summary>
        /// Command - V
        /// </summary>
        /// <param name="amount">Amount in fractional units (i.e. Cents, Tetris)</param>
        /// <returns></returns>
        public async Task<RegisterTransactionResult> RegisterTransactionAsync(int amount, CurrencyCode currency, string clientIpAddress, string description, string language = PaymentUiLanguage.Georgian, string merchantTransactionId = null)
        {
            var options = GetActiveOptions(currency);

            var requestParameters = new Dictionary<string, string>()
            {
                { "command", "v" },
                { "msg_type", "SMS" },
                { "amount", amount.ToString() },
                { "currency", ((int)currency).ToString() },
                { "client_ip_addr", clientIpAddress },
                { "description", description },
                { "language", language },
                { "mrch_transaction_id", merchantTransactionId }
            };

            return new RegisterTransactionResult(await MakePostRequestAsync(requestParameters, options));
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
            if (amount == 0)
            {
                return await RegisterTransactionAndGetReoccuringPaymentIdWithoutChargeAsync(currency, clientIpAddress, description, recurringPaymentUniqueId, expiryDate, language, merchantTransactionId);
            }

            var options = GetActiveOptions(currency);

            expiryDate = expiryDate ?? GetDefaultExpiryDate();

            var requestParameters = new Dictionary<string, string>()
            {
                { "command", "z" },
                { "msg_type", "SMS" },
                { "amount", amount.ToString() },
                { "currency", ((int)currency).ToString() },
                { "client_ip_addr", clientIpAddress },
                { "description", description },
                { "language", language },
                { "biller_client_id", recurringPaymentUniqueId },
                { "perspayee_expiry", expiryDate.Value.ToString("MMyy") },
                { "perspayee_gen", "1" },
                { "mrch_transaction_id", merchantTransactionId }
            };

            return new RegisterTransactionResult(await MakePostRequestAsync(requestParameters, options));
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
            var options = GetActiveOptions(currency);

            expiryDate = expiryDate ?? GetDefaultExpiryDate();

            var requestParameters = new Dictionary<string, string>()
            {
                { "command", "p" },
                { "msg_type", "AUTH" },
                { "currency", ((int)currency).ToString() },
                { "client_ip_addr", clientIpAddress },
                { "description", description },
                { "language", language },
                { "biller_client_id", recurringPaymentUniqueId },
                { "perspayee_expiry", expiryDate.Value.ToString("MMyy") },
                { "perspayee_gen", "1" },
                { "mrch_transaction_id", merchantTransactionId }
            };

            return new RegisterTransactionResult(await MakePostRequestAsync(requestParameters, options));
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
            var options = GetActiveOptions(currency);

            var requestParameters = new Dictionary<string, string>()
            {
                { "command", "e" },
                { "amount", amount.ToString() },
                { "currency", ((int)currency).ToString() },
                { "client_ip_addr", clientIpAddress },
                { "description", description },
                { "desc", description },
                { "language", language },
                { "biller_client_id", billerClientId },
                { "mrch_transaction_id", merchantTransactionId }
            };

            return new ExecuteReoccurringTransactionResult(await MakePostRequestAsync(requestParameters, options));
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
            var options = GetActiveOptions(currency);

            var requestParameters = new Dictionary<string, string>()
            {
                { "command", "a" },
                { "msg_type", "DMS" },
                { "amount", amount.ToString() },
                { "currency", ((int)currency).ToString() },
                { "client_ip_addr", clientIpAddress },
                { "description", description },
                { "language", language },
                { "mrch_transaction_id", merchantTransactionId }
            };

            return new RegisterTransactionResult(await MakePostRequestAsync(requestParameters, options));
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
            var options = GetActiveOptions(currency);

            var requestParameters = new Dictionary<string, string>()
            {
                { "command", "t" },
                { "msg_type", "DMS" },
                { "trans_id", transactionId },
                { "amount", amount.ToString() },
                { "currency", ((int)currency).ToString() },
                { "client_ip_addr", clientIpAddress },
                { "description", description },
                { "desc", description },
            };

            return new ExecutePreAuthorizationResult(await MakePostRequestAsync(requestParameters, options));
        }

        /// <summary>
        /// Command - C
        /// </summary>
        /// <param name="transactionId"></param>
        /// <param name="clientIpAddress"></param>
        /// <returns></returns>
        public async Task<CheckTransactionResult> CheckTransactionResultAsync(string transactionId, string clientIpAddress)
        {
            var options = GetActiveOptions();

            var requestParameters = new Dictionary<string, string>()
            {
                { "command", "c" },
                { "trans_id", transactionId },
                { "client_ip_addr", clientIpAddress }
            };

            return new CheckTransactionResult(await MakePostRequestAsync(requestParameters, options));
        }

        /// <summary>
        /// Command - R
        /// </summary>
        /// <param name="transactionId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public async Task<ReverseTransactionResult> ReverseTransactionAsync(string transactionId, int amount)
        {
            var options = GetActiveOptions();

            var requestParameters = new Dictionary<string, string>()
            {
                { "command", "r" },
                { "trans_id", transactionId },
                { "amount", amount.ToString() }
            };

            return new ReverseTransactionResult(await MakePostRequestAsync(requestParameters, options));
        }

        /// <summary>
        /// Command - K
        /// </summary>
        /// <param name="transactionId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public async Task<RefundTransactionResult> RefundTransactionAsync(string transactionId, int amount)
        {
            var options = GetActiveOptions();

            var requestParameters = new Dictionary<string, string>()
            {
                { "command", "k" },
                { "trans_id", transactionId },
                { "amount", amount.ToString() }
            };

            return new RefundTransactionResult(await MakePostRequestAsync(requestParameters, options));
        }

        /// <summary>
        /// Command - G
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="billerClientId"></param>
        /// <param name="description"></param>
        /// <param name="merchantTransactionId"></param>
        /// <returns></returns>
        public async Task<ExecuteCreditTransactionResult> ExecuteCreditTransactionAsync(int amount, CurrencyCode currency, string billerClientId, string description, string merchantTransactionId = null)
        {
            var options = GetActiveOptions();

            var requestParameters = new Dictionary<string, string>()
            {
                { "command", "ag" },
                { "amount", amount.ToString() },
                { "currency", ((int)currency).ToString() },
                { "trans_id", billerClientId },
                { "description", description },
                { "mrch_transaction_id", merchantTransactionId }
            };

            return new ExecuteCreditTransactionResult(await MakePostRequestAsync(requestParameters, options));
        }

        /// <summary>
        /// Command - B
        /// </summary>
        /// <returns></returns>
        public async Task<CloseBusinessDayResult> CloseBusinessDayAsync()
        {
            var options = GetActiveOptions();

            var requestParameters = new Dictionary<string, string>()
            {
                { "command", "b" },
            };

            return new CloseBusinessDayResult(await MakePostRequestAsync(requestParameters, options));
        }

        /// <summary>
        /// Gets redirect URL where the client should be navigated to enter card details
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        public string GetClientRedirectUrl(string transactionId)
        {
            var options = GetActiveOptions();

            var url = ServiceUrlBuilderHelper.GetClientHandlerUrl(options.Environment);
            return $"{url}?trans_id={System.Web.HttpUtility.UrlEncode(transactionId)}";
        }

        /// <summary>
        /// Sets the specific merchant to use when communicating with the Bank.
        /// If you use multiple mechants you should explicitly call this method to set a specific active merchant, that will be used by other methods,
        /// otherwise the system will try to find a matching merchant automatically and might not select the one you might actually need.
        /// </summary>
        /// <param name="merchantId">MerchantID specified in the configuration options</param>
        /// <exception cref="TbcBankEcommerceClientConfigurationException">Thrown when merchant configuration not found</exception>
        public void SelectMerchant(string merchantId)
        {
            var merchantOptions = _optionsList
                .FirstOrDefault(o => o.MerchantId == merchantId);

            if (merchantOptions == null)
                throw new TbcBankEcommerceClientConfigurationException($"Merchant configuration not found with the id '{merchantId}'");

            _manuallySetActiveOptions = merchantOptions;
        }

        /// <summary>
        /// Sets the specific merchant to use when communicating with the Bank.
        /// If you use multiple mechants you should explicitly call this method to set a specific active merchant, that will be used by other methods,
        /// otherwise the system will try to find a matching merchant automatically and might not select the one you might actually need.
        /// </summary>
        /// <param name="predicate">Will provide list of all available options. Will select the first option where the match returns true. Used LINQ FirstOrDefault internally</param>
        /// <exception cref="TbcBankEcommerceClientConfigurationException">Thrown when merchant configuration not found</exception>
        public void SelectMerchant(Func<TbcBankEcommerceClientOptions, bool> predicate)
        {
            var merchantOptions = _optionsList
                .FirstOrDefault(predicate);

            if (merchantOptions == null)
                throw new TbcBankEcommerceClientConfigurationException($"Merchant configuration not found using the predicate");

            _manuallySetActiveOptions = merchantOptions;
        }

        /// <summary>
        /// Sets the specific merchant to use when communicating with the Bank.
        /// If you use multiple mechants you should explicitly call this method to set a specific active merchant, that will be used by other methods,
        /// otherwise the system will try to find a matching merchant automatically and might not select the one you might actually need.
        /// </summary>
        /// <param name="currency">Currency to search for</param>
        /// <exception cref="TbcBankEcommerceClientConfigurationException">Thrown when merchant configuration not found or more than one merchant configuration found with the specified currency</exception>
        public void SelectMerchant(CurrencyCode currency)
        {
            var merchantOptionsList = _optionsList
                .Where(o => o.Currencies.Contains(currency))
                .ToList();

            if (merchantOptionsList.Count == 0)
                throw new TbcBankEcommerceClientConfigurationException($"Merchant configuration not found using the speficied currency '{currency.ToString()}'");

            if (merchantOptionsList.Count > 1)
                throw new TbcBankEcommerceClientConfigurationException($"More than one merchant configuration not found using the speficied currency '{currency.ToString()}'");

            _manuallySetActiveOptions = merchantOptionsList
                .First();
        }

        private TbcBankEcommerceClientOptions GetActiveOptions(CurrencyCode? currency = null)
        {
            if (_manuallySetActiveOptions != null)
                return _manuallySetActiveOptions;

            TbcBankEcommerceClientOptions activeOptions = null;

            if (currency.HasValue)
            {
                List<TbcBankEcommerceClientOptions> currencyDefinedOptions = _optionsList
                    .Where(o =>
                        o.Currencies != null
                        && o.Currencies.Contains(currency.Value))
                    .ToList();

                if (currencyDefinedOptions.Count > 1)
                    throw new TbcBankEcommerceClientConfigurationException($"More than one merchant configuration not found using the speficied currency '{currency.Value}'");

                activeOptions = currencyDefinedOptions
                    .FirstOrDefault();
            }

            if (activeOptions == null)
                activeOptions = _optionsList
                    .FirstOrDefault();

            if (activeOptions == null)
                throw new TbcBankEcommerceClientConfigurationException("Failed to auto-select active options");

            return activeOptions;
        }
        private DateTimeOffset GetDefaultExpiryDate()
        {
            return DateTimeOffset.UtcNow.Date.AddYears(10);
        }
        private async Task<HttpRequestResult> MakePostRequestAsync(IDictionary<string, string> requestParameters, TbcBankEcommerceClientOptions options)
        {
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
                RequestUrl = ServiceUrlBuilderHelper.GetMerchantHandlerUrl(options.Environment),
                RequestQuery = queryBuilder.ToString()
            };

            try
            {
                using var content = new StringContent(result.RequestQuery, Encoding.UTF8, "application/x-www-form-urlencoded");
                HttpClient client = _merchantHttpClientFactory.GetHttpClient(options);
                HttpResponseMessage responseMessage = await client.PostAsync(result.RequestUrl, content);

                result.HttpStatsCode = responseMessage.StatusCode;
                result.Success = responseMessage.IsSuccessStatusCode;
                result.RawResponse = await responseMessage.Content.ReadAsStringAsync();

                responseMessage.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Exception = ex;
            }

            return result;
        }
        //private HttpClientHandler GetHttpClientHandler(TbcBankEcommerceClientOptions options)
        //{
        //    if (options.Environment == TbcEnvironment.LegacyProduction)
        //        return new HttpClientHandler
        //        {
        //            ClientCertificateOptions = ClientCertificateOption.Manual
        //        };

        //    return new HttpClientHandler
        //    {
        //        ClientCertificateOptions = ClientCertificateOption.Manual,
        //        SslProtocols = SslProtocols.Tls12,
        //    };
        //}
        //private X509Certificate2 CreateCertificate(TbcBankEcommerceClientOptions options)
        //{
        //    try
        //    {
        //        return options.CertData != null
        //              ? new X509Certificate2(options.CertData, options.CertPassword, X509KeyStorageFlags.MachineKeySet)
        //              : new X509Certificate2(options.CertPath, options.CertPassword, X509KeyStorageFlags.MachineKeySet);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Failed to create X509Certificate2", ex);
        //    }
        //}
    }
}
