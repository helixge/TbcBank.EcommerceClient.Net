using System;
using System.Collections.Generic;
using System.Text;

namespace TbcBank.EcommerceClient
{
    public static class ServiceUrlBuilder
    {
        public const string ProductionMerchantHandlerEndpoint = "https://ecommerce.ufc.ge:18443/ecomm2/MerchantHandler";
        public const string ProductionClientHandlerEndpoint = "https://ecommerce.ufc.ge/ecomm2/ClientHandler";

        public const string TestMerchantHandlerEndpoint = "https://ecommercetest.ufc.ge:18443/ecomm2/MerchantHandler";
        public const string TestClientHandlerEndpoint = "https://ecommercetest.ufc.ge:8443/ecomm2/ClientHandler";

        public static string GetMerchantHandlerUrl(Environment environment)
        {
            return environment == Environment.Test
                ? TestMerchantHandlerEndpoint
                : ProductionMerchantHandlerEndpoint;
        }
        public static string GetClientHandlerUrl(Environment environment)
        {
            return environment == Environment.Test
                ? TestClientHandlerEndpoint
                : ProductionClientHandlerEndpoint;
        }
    }
}
