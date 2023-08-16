using Xunit;

namespace TbcBank.EcommerceClient.Tests.Helpers
{
    public class PaymentMethodHelperTests
    {
        [Fact]
        public void GetLanguagePaymentMethodPrefix_ShouldReturnStringEmpty_WhenInputValueIsNull()
        {
            PaymentMethod[] input = null;
            string expected = string.Empty;

            string actual = PaymentMethodHelper.GetLanguagePaymentMethodPrefix(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetLanguagePaymentMethodPrefix_ShouldReturnStringEmpty_WhenInputValueIsEmpty()
        {
            PaymentMethod[] input = new PaymentMethod[0];
            string expected = string.Empty;

            string actual = PaymentMethodHelper.GetLanguagePaymentMethodPrefix(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetLanguagePaymentMethodPrefix_ShouldReturnStringEmpty_WhenInputValueIncludeCardOnly()
        {
            PaymentMethod[] input = new[] { PaymentMethod.Card };
            string expected = string.Empty;

            string actual = PaymentMethodHelper.GetLanguagePaymentMethodPrefix(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetLanguagePaymentMethodPrefix_ShouldReturnGooglePayPrefix_WhenInputValueIncludeGooglePayOnly()
        {
            PaymentMethod[] input = new[] { PaymentMethod.GooglePay };
            string expected = PaymentLanguagePrefix.GooglePay;

            string actual = PaymentMethodHelper.GetLanguagePaymentMethodPrefix(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetLanguagePaymentMethodPrefix_ShouldReturnApplePayPrefix_WhenInputValueIncludeApplePayOnly()
        {
            PaymentMethod[] input = new[] { PaymentMethod.ApplePay };
            string expected = PaymentLanguagePrefix.ApplePay;

            string actual = PaymentMethodHelper.GetLanguagePaymentMethodPrefix(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetLanguagePaymentMethodPrefix_ShouldReturnGooglePayApplePayPrefix_WhenInputValueIncludesGooglePayAndApplePay()
        {
            PaymentMethod[] input = new[] { PaymentMethod.GooglePay, PaymentMethod.ApplePay };
            string expected = $"{PaymentLanguagePrefix.GooglePay}{PaymentLanguagePrefix.ApplePay}";

            string actual = PaymentMethodHelper.GetLanguagePaymentMethodPrefix(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetLanguagePaymentMethodPrefix_ShouldReturnGooglePayApplePayPrefix_WhenInputValueIncludesApplePayAndGooglePay()
        {
            PaymentMethod[] input = new[] { PaymentMethod.ApplePay, PaymentMethod.GooglePay };
            string expected = $"{PaymentLanguagePrefix.GooglePay}{PaymentLanguagePrefix.ApplePay}";

            string actual = PaymentMethodHelper.GetLanguagePaymentMethodPrefix(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetLanguagePaymentMethodPrefix_ShouldReturnGooglePayCardPrefix_WhenInputValueIncludesGooglePayAndCard()
        {
            PaymentMethod[] input = new[] { PaymentMethod.GooglePay, PaymentMethod.Card };
            string expected = $"{PaymentLanguagePrefix.GooglePay}{PaymentLanguagePrefix.Card}";

            string actual = PaymentMethodHelper.GetLanguagePaymentMethodPrefix(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetLanguagePaymentMethodPrefix_ShouldReturnGooglePayCardPrefix_WhenInputValueIncludesCardAndGooglePay()
        {
            PaymentMethod[] input = new[] { PaymentMethod.Card, PaymentMethod.GooglePay };
            string expected = $"{PaymentLanguagePrefix.GooglePay}{PaymentLanguagePrefix.Card}";

            string actual = PaymentMethodHelper.GetLanguagePaymentMethodPrefix(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetLanguagePaymentMethodPrefix_ShouldReturnCardApplePayPrefix_WhenInputValueIncludesCardAndApplePay()
        {
            PaymentMethod[] input = new[] { PaymentMethod.Card, PaymentMethod.ApplePay };
            string expected = $"{PaymentLanguagePrefix.ApplePay}{PaymentLanguagePrefix.Card}";

            string actual = PaymentMethodHelper.GetLanguagePaymentMethodPrefix(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetLanguagePaymentMethodPrefix_ShouldReturnCardApplePayPrefix_WhenInputValueIncludesApplePayAndCard()
        {
            PaymentMethod[] input = new[] { PaymentMethod.ApplePay, PaymentMethod.Card };
            string expected = $"{PaymentLanguagePrefix.ApplePay}{PaymentLanguagePrefix.Card}";

            string actual = PaymentMethodHelper.GetLanguagePaymentMethodPrefix(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetLanguagePaymentMethodPrefix_ShouldReturnGooglePayApplePayCardPrefix_WhenInputValueIncludesGooglePayCardApplePay()
        {
            PaymentMethod[] input = new[] { PaymentMethod.GooglePay, PaymentMethod.Card, PaymentMethod.ApplePay };
            string expected = $"{PaymentLanguagePrefix.GooglePay}{PaymentLanguagePrefix.ApplePay}{PaymentLanguagePrefix.Card}";

            string actual = PaymentMethodHelper.GetLanguagePaymentMethodPrefix(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetLanguagePaymentMethodPrefix_ShouldReturnGooglePayApplePayCardPrefix_WhenInputValueIncludesGooglePayApplePayCard()
        {
            PaymentMethod[] input = new[] { PaymentMethod.GooglePay, PaymentMethod.ApplePay, PaymentMethod.Card };
            string expected = $"{PaymentLanguagePrefix.GooglePay}{PaymentLanguagePrefix.ApplePay}{PaymentLanguagePrefix.Card}";

            string actual = PaymentMethodHelper.GetLanguagePaymentMethodPrefix(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetLanguagePaymentMethodPrefix_ShouldReturnGooglePayApplePayCardPrefix_WhenInputValueIncludesCardGooglePayApplePay()
        {
            PaymentMethod[] input = new[] { PaymentMethod.Card, PaymentMethod.GooglePay, PaymentMethod.ApplePay };
            string expected = $"{PaymentLanguagePrefix.GooglePay}{PaymentLanguagePrefix.ApplePay}{PaymentLanguagePrefix.Card}";

            string actual = PaymentMethodHelper.GetLanguagePaymentMethodPrefix(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetLanguagePaymentMethodPrefix_ShouldReturnGooglePayApplePayCardPrefix_WhenInputValueIncludesCardApplePayGooglePay()
        {
            PaymentMethod[] input = new[] { PaymentMethod.Card, PaymentMethod.ApplePay, PaymentMethod.GooglePay };
            string expected = $"{PaymentLanguagePrefix.GooglePay}{PaymentLanguagePrefix.ApplePay}{PaymentLanguagePrefix.Card}";

            string actual = PaymentMethodHelper.GetLanguagePaymentMethodPrefix(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetLanguagePaymentMethodPrefix_ShouldReturnGooglePayApplePayCardPrefix_WhenInputValueIncludesApplePayCardGooglePay()
        {
            PaymentMethod[] input = new[] { PaymentMethod.ApplePay, PaymentMethod.Card, PaymentMethod.GooglePay };
            string expected = $"{PaymentLanguagePrefix.GooglePay}{PaymentLanguagePrefix.ApplePay}{PaymentLanguagePrefix.Card}";

            string actual = PaymentMethodHelper.GetLanguagePaymentMethodPrefix(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetLanguagePaymentMethodPrefix_ShouldReturnGooglePayApplePayCardPrefix_WhenInputValueIncludesApplePayGooglePayCard()
        {
            PaymentMethod[] input = new[] { PaymentMethod.ApplePay, PaymentMethod.GooglePay, PaymentMethod.Card };
            string expected = $"{PaymentLanguagePrefix.GooglePay}{PaymentLanguagePrefix.ApplePay}{PaymentLanguagePrefix.Card}";

            string actual = PaymentMethodHelper.GetLanguagePaymentMethodPrefix(input);

            Assert.Equal(expected, actual);
        }
    }
}
