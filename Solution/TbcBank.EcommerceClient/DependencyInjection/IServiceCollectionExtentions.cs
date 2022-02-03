using System.Collections.Generic;
using TbcBank.EcommerceClient;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtentions
    {
        public static IServiceCollection AddTbcBankEcommerce(this IServiceCollection services, IEnumerable<TbcBankEcommerceClientOptions> options)
        {
            services.AddSingleton<IMerchantHttpClientFactory, MerchantHttpClientFactory>();
            services.AddTransient<TbcBankEcommerceClient, TbcBankEcommerceClient>();

            foreach (TbcBankEcommerceClientOptions optionsEntry in options)
            {
                services.AddTransient(_ => optionsEntry);
            }

            return services;
        }
    }
}
