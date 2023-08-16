using Xunit;

namespace TbcBank.EcommerceClient.Tests.Models.Operation
{
    public class ExecuteReoccurringTransactionResponseTests
    {
        [Theory]
        [InlineData(true, "RESULT: TIMEOUT\nRECC_PMNT_ID: dca7c375-edf9-4306-a500-4e8573434ad8\nRECC_PMNT_EXPIRY: 0730")]
        [InlineData(true, "TRANSACTION_ID: qVuboVuAmgVBiskWnVkpzwUpUps=\nRESULT: FAILED\nRESULT_CODE: 116")]
        [InlineData(true, "error: Perspayee data expired or missing\nTRANSACTION_ID: x7rvnuYSF4rvnnInTIhVvcSXdaM=\nRESULT: FAILED")]
        [InlineData(true, "TRANSACTION_ID: u7RTOrq6HVAnEqWshlWJUngSDKc=\nRESULT: FAILED\nRESULT_CODE: 204")]
        [InlineData(false, "TRANSACTION_ID: qPw4rEgy6WaYvUPweJaZoMpuo9Y=\nRESULT: OK\nRESULT_CODE: 000\nRRN: 019715123832\nAPPROVAL_CODE: 715649")]
        public void IsError_TestSpecificCases(bool isError, string rawResponse)
        {
            //Arrange
            var result = new ExecuteReoccurringTransactionResult(new HttpRequestResult()
            {
                RawResponse = rawResponse
            });

            //Assert
            Assert.Equal(result.IsError, isError);
        }
    }
}
