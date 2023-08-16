using Xunit;

namespace TbcBank.EcommerceClient.Tests.Helpers
{
    public class ResponseProcessingHelperTests
    {
        [Fact]
        public void FixBillerClientIdUfcResponse_ShouldReturnNull_WhenNullPassedIn()
        {
            string input = null;

            string actual = ResponseProcessingHelper.FixBillerClientIdUfcResponse(input);

            Assert.Null(actual);
        }

        [Fact]
        public void FixBillerClientIdUfcResponse_ShouldReturnInputValue_WhenInputValueLengthIsLessThan4Characters()
        {
            string input = "123";

            string actual = ResponseProcessingHelper.FixBillerClientIdUfcResponse(input);

            Assert.Equal(input, actual);
        }

        [Fact]
        public void FixBillerClientIdUfcResponse_ShouldReturnInputValue_WhenInputValueDoesNotEndWithBillerClientIdSuffixAddedByUfc()
        {
            string input = "1234567890";

            string actual = ResponseProcessingHelper.FixBillerClientIdUfcResponse(input);

            Assert.Equal(input, actual);
        }

        [Fact]
        public void FixBillerClientIdUfcResponse_ShouldReturnInputValueWithoutBillerClientIdSuffixAddedByUfc_WhenInputValueEndsWithBillerClientIdSuffixAddedByUfc()
        {
            string billerClientId = "1234567890";
            string input = $"{billerClientId}{ResponseProcessingHelper.BillerClientIdSuffixAddedByUfc}";

            string actual = ResponseProcessingHelper.FixBillerClientIdUfcResponse(input);

            Assert.Equal(billerClientId, actual);
        }
    }
}
