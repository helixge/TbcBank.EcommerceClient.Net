using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TbcBank.EcommerceClient.Tests.Models.Operation
{
    public class CheckTransactionResultResponseTests
    {
        [Theory]
        [InlineData(true, "RESULT: TIMEOUT\nRECC_PMNT_ID: dca7c375-edf9-4306-a500-4e8573434ad8\nRECC_PMNT_EXPIRY: 0730")]
        [InlineData(true, "TRANSACTION_ID: qVuboVuAmgVBiskWnVkpzwUpUps=\nRESULT: FAILED\nRESULT_CODE: 116")]
        [InlineData(true, "error: Perspayee data expired or missing\nTRANSACTION_ID: x7rvnuYSF4rvnnInTIhVvcSXdaM=\nRESULT: FAILED")]
        [InlineData(true, "TRANSACTION_ID: u7RTOrq6HVAnEqWshlWJUngSDKc=\nRESULT: FAILED\nRESULT_CODE: 204")]
        [InlineData(false, "TRANSACTION_ID: qPw4rEgy6WaYvUPweJaZoMpuo9Y=\nRESULT: OK\nRESULT_CODE: 000\nRRN: 019715123832\nAPPROVAL_CODE: 715649")]
        [InlineData(false, "RESULT: OK\nRESULT_CODE: 000\n3DSECURE: AUTHENTICATED\nRRN: 019813023831\nAPPROVAL_CODE: 455319\nCARD_NUMBER: 5***********6968\nRECC_PMNT_ID: fa8e62f0-0f2e-4118-8e20-a92da956b21b\nRECC_PMNT_EXPIRY: 0323")]
        [InlineData(false, "RESULT: OK\nRESULT_CODE: 000\n3DSECURE: ATTEMPTED\nRRN: 011918566115\nAPPROVAL_CODE: 968894\nCARD_NUMBER: 4***********5731\nRECC_PMNT_ID: caea81fc-826c-4d68-9c35-fefe091eed00\nRECC_PMNT_EXPIRY: 0523")]
        [InlineData(true, "RESULT: FAILED\nRESULT_CODE: 111\n3DSECURE: NOTPARTICIPATED\nRRN: 009521512954\nCARD_NUMBER: 5***********1762\nRECC_PMNT_ID: bb79ad9f-1888-45e9-9aa2-a7e4100f11e9\nRECC_PMNT_EXPIRY: 1020")]
        [InlineData(true, "RESULT: DECLINED\n3DSECURE: ERROR\nCARD_NUMBER: 4***********5684\nRECC_PMNT_ID: 9ed2ad04-08cd-4ca6-ae8d-9208758495b9\nRECC_PMNT_EXPIRY: 1222")]
        public void IsError_TestSpecificCases(bool isError, string rawResponse)
        {
            //Arrange
            var result = new CheckTransactionResultResponse(new HttpRequestResult()
            {
                RawResponse = rawResponse
            });

            //Assert
            Assert.Equal(result.IsError, isError);
        }
    }
}
