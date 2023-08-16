using System.Linq;

namespace TbcBank.EcommerceClient
{
    public static class PaymentMethodHelper
    {
        public static string GetLanguagePaymentMethodPrefix(PaymentMethod[] paymentMethods)
        {
            string languagePrefix = string.Empty;

            if (paymentMethods is null)
            {
                return languagePrefix;
            }

            if (paymentMethods.Contains(PaymentMethod.Card)
                && !paymentMethods.Any(po => po != PaymentMethod.Card))
            {
                return languagePrefix;
            }

            if (paymentMethods.Contains(PaymentMethod.GooglePay))
            {
                languagePrefix += PaymentLanguagePrefix.GooglePay;
            }

            if (paymentMethods.Contains(PaymentMethod.ApplePay))
            {
                languagePrefix += PaymentLanguagePrefix.ApplePay;
            }

            if (paymentMethods.Contains(PaymentMethod.Card))
            {
                languagePrefix += PaymentLanguagePrefix.Card;
            }

            return languagePrefix;
        }
    }
}
