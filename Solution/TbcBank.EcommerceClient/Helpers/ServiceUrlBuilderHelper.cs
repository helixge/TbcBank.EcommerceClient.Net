using System;
using System.Collections.Generic;
using System.Text;

namespace TbcBank.EcommerceClient
{
    public static class ServiceUrlBuilderHelper
    {
        public const string ProductionMerchantHandlerEndpoint = "https://ecommerce.ufc.ge:18443/ecomm2/MerchantHandler";
        public const string ProductionClientHandlerEndpoint = "https://ecommerce.ufc.ge/ecomm2/ClientHandler";

        public const string TestMerchantHandlerEndpoint = "https://ecommercetest.ufc.ge:18443/ecomm2/MerchantHandler";
        public const string TestClientHandlerEndpoint = "https://ecommercetest.ufc.ge:8443/ecomm2/ClientHandler";

        public const string LegacyProductionMerchantHandlerEndpoint = "https://securepay.ufc.ge:18443/ecomm2/MerchantHandler";
        public const string LegacyProductionClientHandlerEndpoint = "https://securepay.ufc.ge/ecomm2/ClientHandler";


        public static string GetMerchantHandlerUrl(TbcEnvironment environment)
        {
            switch (environment)
            {
                case TbcEnvironment.Production:
                    return ProductionMerchantHandlerEndpoint;

                case TbcEnvironment.Test:
                    return TestMerchantHandlerEndpoint;
                    
                case TbcEnvironment.LegacyProduction:
                    return LegacyProductionMerchantHandlerEndpoint;

                default:
                    throw new NotImplementedException($"Unimplemented envirionment: {environment.ToString()} ({(int)environment})");
            }
        }
        public static string GetClientHandlerUrl(TbcEnvironment environment)
        {
            switch (environment)
            {
                case TbcEnvironment.Production:
                    return ProductionClientHandlerEndpoint;

                case TbcEnvironment.Test:
                    return TestClientHandlerEndpoint;

                case TbcEnvironment.LegacyProduction:
                    return LegacyProductionClientHandlerEndpoint;

                default:
                    throw new NotImplementedException($"Unimplemented envirionment: {environment.ToString()} ({(int)environment})");
            }
        }
    }
}
