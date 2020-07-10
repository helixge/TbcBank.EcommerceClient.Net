using System;
using System.Threading.Tasks;
using TbcBank.EcommerceClient;

namespace TbcBank.Ecommerce.Client.TestApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var clientIpAddress = "127.0.0.1";

            // Test Card Number: 5158819004260164
            // Month: 02
            // Year: 22
            // CVV: 274


            TbcBankEcommerceClientOptions options = new TbcBankEcommerceClientOptions()
            {
                CertPath = "tbc-test-certificate.p12",
                CertPassword = "8xh4-S2wQALdibVV",
                Environment = TbcEnvironment.Test
            };

            TbcBankEcommerceClient client = new TbcBankEcommerceClient(options);

            var closeBusinessDayResult = await client.CloseBusinessDay();

            //var registerTransactionResult = await client.RegisterTransactionAsync(1, CurrencyCode.GEL, clientIpAddress, "Test Transaction - RegisterTransaction", PaymentUiLanguage.Georgian, "MerchantId-001");
            //var redirectUrl1 = client.GetClientRedirectUrl(registerTransactionResult.TransactionId);
            //var checkTransactionResult1 = await client.CheckTransactionResultAsync(registerTransactionResult.TransactionId, clientIpAddress);
            //var reverseResult1 = await client.ReverseTransactionAsync(registerTransactionResult.TransactionId, 1);

            //var preauthorizationResult = await client.RegisterPreAuthorizationAsync(2, CurrencyCode.GEL, clientIpAddress, "Test Transaction - RegisterPreAuthorization", PaymentUiLanguage.English, "MerchantId-001");
            //var redirectUrl2 = client.GetClientRedirectUrl(preauthorizationResult.TransactionId);
            //var checkPreauthorizationResult1 = await client.CheckTransactionResultAsync(preauthorizationResult.TransactionId, clientIpAddress);
            //await client.ExecutePreAuthorizationAsync(preauthorizationResult.TransactionId, 2, CurrencyCode.GEL, clientIpAddress, "Test Transaction - RegisterPreAuthorization - Exec");
            //var checkPreauthorizationExecResult1 = await client.CheckTransactionResultAsync(preauthorizationResult.TransactionId, clientIpAddress);
            //var refundResult1 = await client.RefundTransactionAsync(preauthorizationResult.TransactionId, 1);

            string billerClientId = Guid.NewGuid().ToString();
            //var registerTransactionAndGetReoccuringPaymentIdResult = await client.RegisterTransactionAndGetReoccuringPaymentIdAsync(3, CurrencyCode.GEL, clientIpAddress, "Test Transaction - RegisterTransactionAndGetReoccuringPaymentIdAsync", billerClientId);
            //var redirectUrl3 = client.GetClientRedirectUrl(registerTransactionAndGetReoccuringPaymentIdResult.TransactionId);
            //var checkTransactionAndGetReoccuringPaymentIdResult = await client.CheckTransactionResultAsync(registerTransactionAndGetReoccuringPaymentIdResult.TransactionId, clientIpAddress);
            //if (checkTransactionAndGetReoccuringPaymentIdResult.ReocurringPaymentBillerClientId != billerClientId)
            //{

            //}

            //var executeReoccurringTransactionResult = await client.ExecuteReoccurringTransactionAsync(4, CurrencyCode.GEL, clientIpAddress, "Test Transaction - ExecuteReoccurringTransactionAsync", billerClientId);
            //var checkExecuteReoccurringTransactionResult = await client.CheckTransactionResultAsync(executeReoccurringTransactionResult.TransactionId, clientIpAddress);
            //var reverseResult2 = await client.ReverseTransactionAsync(executeReoccurringTransactionResult.TransactionId, 1);
            //var refundResult2 = await client.RefundTransactionAsync(executeReoccurringTransactionResult.TransactionId, 1);


            var registerTransactionAndGetReoccuringPaymentIdWithoutChargeResult = await client.RegisterTransactionAndGetReoccuringPaymentIdWithoutChargeAsync(CurrencyCode.GEL, clientIpAddress, "Test Transaction - RegisterTransactionAndGetReoccuringPaymentIdAsync", billerClientId);
            var redirectUrl4 = client.GetClientRedirectUrl(registerTransactionAndGetReoccuringPaymentIdWithoutChargeResult.TransactionId);
            var checkTransactionAndGetReoccuringPaymentIdWithoutChargeResult = await client.CheckTransactionResultAsync(registerTransactionAndGetReoccuringPaymentIdWithoutChargeResult.TransactionId, clientIpAddress);
            if (checkTransactionAndGetReoccuringPaymentIdWithoutChargeResult.ReocurringPaymentBillerClientId != billerClientId)
            {

            }
        }
    }
}
