using System;
using System.Diagnostics;
using System.Threading.Tasks;
using TbcBank.EcommerceClient;

namespace TbcBank.Ecommerce.Client.TestApp
{
    class Program
    {
        const string ClientIpAddress = "127.0.0.1";

        static async Task Main(string[] args)
        {
            IMerchantHttpClientFactory merchantHttpClientFactory = new MerchantHttpClientFactory();

            var options = new TbcBankEcommerceClientOptions()
            {
                CertPath = @"C:\Temp\tbc-test-certificate.pfx",
                CertPassword = "-CERTIFICATE-PASSWORD-",
                Environment = TbcEnvironment.Production
            };
            TbcBankEcommerceClient client = new TbcBankEcommerceClient(merchantHttpClientFactory, new[] { options });

            CloseBusinessDayResult closeBusinessDayResult
                = await client.CloseBusinessDayAsync();

            {
                RegisterTransactionResult registerTransactionResult
                    = await client.RegisterTransactionAsync(1, CurrencyCode.GEL, ClientIpAddress, "Test Transaction - RegisterTransaction", PaymentUiLanguage.Georgian, "MerchantId-001");
                string redirectUrl
                    = client.GetClientRedirectUrl(registerTransactionResult.TransactionId);

                OpenUrlInBworser(redirectUrl);

                CheckTransactionResult checkTransactionResult
                    = await client.CheckTransactionResultAsync(registerTransactionResult.TransactionId, ClientIpAddress);
                ReverseTransactionResult reverseResult
                    = await client.ReverseTransactionAsync(registerTransactionResult.TransactionId, 1);
            }

            {
                RegisterTransactionResult preauthorizationResult
                    = await client.RegisterPreAuthorizationAsync(2, CurrencyCode.GEL, ClientIpAddress, "Test Transaction - RegisterPreAuthorization", PaymentUiLanguage.English, "MerchantId-001");
                string redirectUrl
                    = client.GetClientRedirectUrl(preauthorizationResult.TransactionId);

                OpenUrlInBworser(redirectUrl);

                CheckTransactionResult checkPreauthorizationResult1
                    = await client.CheckTransactionResultAsync(preauthorizationResult.TransactionId, ClientIpAddress);
                await client.ExecutePreAuthorizationAsync(preauthorizationResult.TransactionId, 2, CurrencyCode.GEL, ClientIpAddress, "Test Transaction - RegisterPreAuthorization - Exec");
                CheckTransactionResult checkPreauthorizationExecResul
                    = await client.CheckTransactionResultAsync(preauthorizationResult.TransactionId, ClientIpAddress);
                RefundTransactionResult refundResult
                    = await client.RefundTransactionAsync(preauthorizationResult.TransactionId, 1);
            }

            {
                string billerClientId = Guid.NewGuid().ToString();
                RegisterTransactionResult registerTransactionAndGetReoccuringPaymentIdResult
                    = await client.RegisterTransactionAndGetReoccuringPaymentIdAsync(3, CurrencyCode.GEL, ClientIpAddress, "Test Transaction - RegisterTransactionAndGetReoccuringPaymentIdAsync", billerClientId);
                string redirectUrl
                    = client.GetClientRedirectUrl(registerTransactionAndGetReoccuringPaymentIdResult.TransactionId);

                OpenUrlInBworser(redirectUrl);

                CheckTransactionResult checkTransactionAndGetReoccuringPaymentIdResult
                    = await client.CheckTransactionResultAsync(registerTransactionAndGetReoccuringPaymentIdResult.TransactionId, ClientIpAddress);
            }

            {
                string billerClientId = Guid.NewGuid().ToString();
                ExecuteReoccurringTransactionResult executeReoccurringTransactionResult
                    = await client.ExecuteReoccurringTransactionAsync(4, CurrencyCode.GEL, ClientIpAddress, "Test Transaction - ExecuteReoccurringTransactionAsync", billerClientId);
                CheckTransactionResult checkExecuteReoccurringTransactionResult
                    = await client.CheckTransactionResultAsync(executeReoccurringTransactionResult.TransactionId, ClientIpAddress);
                ReverseTransactionResult reverseResult
                    = await client.ReverseTransactionAsync(executeReoccurringTransactionResult.TransactionId, 1);
                RefundTransactionResult refundResult
                    = await client.RefundTransactionAsync(executeReoccurringTransactionResult.TransactionId, 1);
            }

            {
                string billerClientId = Guid.NewGuid().ToString();
                RegisterTransactionResult registerTransactionResult
                    = await client.RegisterTransactionAndGetReoccuringPaymentIdWithoutChargeAsync(CurrencyCode.GEL, ClientIpAddress, "Test Transaction - RegisterTransactionAndGetReoccuringPaymentIdAsync", billerClientId);
                string redirectUrl
                    = client.GetClientRedirectUrl(registerTransactionResult.TransactionId);

                OpenUrlInBworser(redirectUrl);

                var checkTransactionAndGetReoccuringPaymentIdWithoutChargeResult = await client.CheckTransactionResultAsync((await client.RegisterTransactionAndGetReoccuringPaymentIdWithoutChargeAsync(CurrencyCode.GEL, ClientIpAddress, "Test Transaction - RegisterTransactionAndGetReoccuringPaymentIdAsync", billerClientId)).TransactionId, ClientIpAddress);
            }
        }

        private static void OpenUrlInBworser(string url)
        {
            Process.Start(url);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
