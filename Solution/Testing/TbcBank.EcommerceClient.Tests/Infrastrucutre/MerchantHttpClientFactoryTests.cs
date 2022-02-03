using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace TbcBank.EcommerceClient.Tests.Infrastrucutre
{
    public class MerchantHttpClientFactoryTests
    {
        private readonly MerchantHttpClientFactory _sut;

        public MerchantHttpClientFactoryTests()
        {
            _sut = new MerchantHttpClientFactory();
        }

        [Fact]
        public void GetHttpClient_ValidOptions_ReturnsNewInstance()
        {
            // Arrange
            TbcBankEcommerceClientOptions options = CreateTestOptions();

            // Act
            HttpClient httpClient = _sut.GetHttpClient(options);

            // Assert
            Assert.NotNull(httpClient);
        }

        [Fact]
        public void GetHttpClient_TwoCallWithTheSameMerchantNameOptions_ReturnsSameInstance()
        {
            // Arrange
            string merchantName = Guid.NewGuid().ToString();
            TbcBankEcommerceClientOptions options1 = CreateTestOptions(merchantName);
            TbcBankEcommerceClientOptions options2 = CreateTestOptions(merchantName);

            // Act
            HttpClient httpClient1 = _sut.GetHttpClient(options1);
            HttpClient httpClient2 = _sut.GetHttpClient(options2);

            // Assert
            Assert.Same(httpClient1, httpClient2);
        }

        [Fact]
        public void GetHttpClient_TwoCallWithTheDifferentMerchantNameOptions_ReturnsSameInstance()
        {
            // Arrange
            string merchantName1 = "1";
            string merchantName2 = "2";
            TbcBankEcommerceClientOptions options1 = CreateTestOptions(merchantName1);
            TbcBankEcommerceClientOptions options2 = CreateTestOptions(merchantName2);

            // Act
            HttpClient httpClient1 = _sut.GetHttpClient(options1);
            HttpClient httpClient2 = _sut.GetHttpClient(options2);

            // Assert
            Assert.NotSame(httpClient1, httpClient2);
        }

        private static TbcBankEcommerceClientOptions CreateTestOptions(string merchantName = "TestMerchant")
        {
            return new TbcBankEcommerceClientOptions()
            {
                MerchantId = merchantName,
                Environment = TbcEnvironment.Production,
                CertPath = TestResource.TestCertificatePath,
                CertPassword = TestResource.TestCertificatePassword
            };
        }
    }
}
