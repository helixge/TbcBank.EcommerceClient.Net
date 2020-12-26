using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TbcBank.EcommerceClient;

namespace Microsoft.Extensions.Configuration
{
    public static class IConfigurationExtentions
    {
        public static IEnumerable<TbcBankEcommerceClientOptions> GetTbcBankEcommerceOptions(this IConfiguration configuration, string key)
        {
            var configurationSection = configuration
                .GetSection(key);

            var options = configurationSection
                .Get<IEnumerable<TbcBankEcommerceClientOptions>>();

            if (options == null)
                throw new TbcBankEcommerceClientConfigurationException($"TBC Bank e-commerce configuration not found with key: {key}");

            if (options.Count() == 0)
                throw new TbcBankEcommerceClientConfigurationException($"TBC Bank e-commerce configuration is empty with key: {key}");

            return options;
        }
    }
}
