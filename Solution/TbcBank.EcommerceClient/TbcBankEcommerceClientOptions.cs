using System;
using System.Linq;

namespace TbcBank.EcommerceClient
{
    public class TbcBankEcommerceClientOptions
    {
        /// <summary>
        /// Merchant ID
        /// </summary>
        public string MerchantId { get; set; }
        /// <summary>
        /// Certificate file content
        /// Either CertData or CertPath should be specified. Do not specify both
        /// </summary>
        public byte[] CertData { get; set; }
        /// <summary>
        /// Certificate file full path
        /// Either CertData or CertPath should be specified. Do not specify both
        /// </summary>
        public string CertPath { get; set; }
        /// <summary>
        /// Certificate password
        /// </summary>
        public string CertPassword { get; set; }
        /// <summary>
        /// TBC Envirionment
        /// </summary>
        public TbcEnvironment Environment { get; set; }
        /// <summary>
        /// Merchant available currencies
        /// </summary>
        public CurrencyCode[] Currencies { get; set; }

        public void Validate(bool validateMerchantIdAndCurrencies)
        {
            if (CertData != null
                && !String.IsNullOrWhiteSpace(CertPath))
                throw new Exception("Invalid options, both CertData and CertPath are assigned. Only one of them can be assigned");

            if (CertData == null
                && String.IsNullOrWhiteSpace(CertPath))
                throw new Exception("Invalid options, neither CertData not CertPath are assigned. One of them should be assigned.");

            if (validateMerchantIdAndCurrencies
                && String.IsNullOrWhiteSpace(MerchantId))
                throw new Exception("Invalid options, merchant ID is not defined");

            if (validateMerchantIdAndCurrencies
                && Currencies != null
                && !Currencies.Any())
                throw new Exception("Invalid options, no currencies have been defined");
        }
    }
}
