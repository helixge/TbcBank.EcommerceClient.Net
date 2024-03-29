﻿namespace TbcBank.EcommerceClient
{
    public static class ResponseProcessingHelper
    {
        public const string BillerClientIdSuffixAddedByUfc = "_oc";

        public static string FixBillerClientIdUfcResponse(string responseBillerClientId)
        {
            if (responseBillerClientId == null)
            {
                return responseBillerClientId;
            }

            if (responseBillerClientId.Length < 4)
            {
                return responseBillerClientId;
            }

            string lastThreeCharacters = responseBillerClientId.Substring(responseBillerClientId.Length - 3, 3);

            if (lastThreeCharacters == BillerClientIdSuffixAddedByUfc)
            {
                return responseBillerClientId.Substring(0, responseBillerClientId.Length - 3);
            }

            return responseBillerClientId;
        }
    }
}
