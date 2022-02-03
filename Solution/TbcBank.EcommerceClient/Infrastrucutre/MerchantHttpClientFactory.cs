using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TbcBank.EcommerceClient
{
    public class MerchantHttpClientFactory : IMerchantHttpClientFactory, IDisposable
    {
        private readonly Dictionary<string, HttpClient> _httpClients;
        private readonly object _httpClientsLocker = new object();

        public MerchantHttpClientFactory()
        {
            _httpClients = new Dictionary<string, HttpClient>();
        }

        public void Dispose()
        {
            foreach (KeyValuePair<string, HttpClient> httpClient in _httpClients)
            {
                httpClient.Value.Dispose();
            }
        }

        public HttpClient GetHttpClient(TbcBankEcommerceClientOptions options)
        {
            string merchantId = options?.MerchantId ?? String.Empty;

            lock (_httpClientsLocker)
            {
                if (!_httpClients.ContainsKey(merchantId))
                {
                    HttpClient httpClient = CreateHttpClient(options);
                    _httpClients.Add(merchantId, httpClient);
                }

                return _httpClients[merchantId];
            }
        }

        private HttpClient CreateHttpClient(TbcBankEcommerceClientOptions options)
        {
            HttpClientHandler handler = CreatettpClientHandler(options);
            var client = new HttpClient(handler);

            return client;
        }

        private HttpClientHandler CreatettpClientHandler(TbcBankEcommerceClientOptions options)
        {
            var httpClientHandler = new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            if (options.Environment != TbcEnvironment.LegacyProduction)
            {
                httpClientHandler.SslProtocols = SslProtocols.Tls12;
            };

            X509Certificate2 certificate = CreateCertificate(options);
            httpClientHandler.ClientCertificates.Add(certificate);

            return httpClientHandler;
        }

        private X509Certificate2 CreateCertificate(TbcBankEcommerceClientOptions options)
        {
            try
            {
                return options.CertData != null
                      ? new X509Certificate2(options.CertData, options.CertPassword, X509KeyStorageFlags.MachineKeySet)
                      : new X509Certificate2(options.CertPath, options.CertPassword, X509KeyStorageFlags.MachineKeySet);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create X509Certificate2", ex);
            }
        }
    }
}
