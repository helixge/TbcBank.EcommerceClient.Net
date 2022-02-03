using System.Collections.Generic;
using TbcBank.EcommerceClient;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtentions
    {
        public static IServiceCollection AddTbcBankEcommerce(this IServiceCollection services, IEnumerable<TbcBankEcommerceClientOptions> options)
        {
            services.AddTransient<TbcBankEcommerceClient, TbcBankEcommerceClient>();

            foreach (var optionsEntry in options)
            {
                services.AddTransient<TbcBankEcommerceClientOptions>(serviceProvider => optionsEntry);
            }

            return services;
        }
    }
}
