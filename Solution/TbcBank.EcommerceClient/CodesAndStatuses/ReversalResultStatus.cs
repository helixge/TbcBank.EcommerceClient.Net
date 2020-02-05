using System;
using System.Collections.Generic;
using System.Text;

namespace TbcBank.EcommerceClient
{
    public static class ReversalResultStatus
    {
        /// <summary>
        /// successful reversal transaction
        /// </summary>
        public const string OK = "OK";
        /// <summary>
        /// transaction has already been reversed
        /// </summary>
        public const string REVERSED = "REVERSED";
        /// <summary>
        /// failed to reverse transaction (transaction status remains as it was)
        /// </summary>
        public const string FAILED = "FAILED";
    }
}
