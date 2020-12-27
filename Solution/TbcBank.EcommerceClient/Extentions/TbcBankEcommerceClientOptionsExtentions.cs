using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TbcBank.EcommerceClient
{
    public static class TbcBankEcommerceClientOptionsExtentions
    {
        public static void Validate(this IEnumerable<TbcBankEcommerceClientOptions> optionsList)
        {
            if (optionsList == null)
                throw new TbcBankEcommerceClientConfigurationException("Options list is null");

            if (optionsList.Count() == 0)
                throw new TbcBankEcommerceClientConfigurationException("Options list is empty");

            var shoudlValidateMerchantIdAndCurrencies = optionsList.Count() > 1;

            foreach (var options in optionsList)
                options.Validate(shoudlValidateMerchantIdAndCurrencies, shoudlValidateMerchantIdAndCurrencies);
        }
    }
}
