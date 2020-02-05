using System;
using System.Collections.Generic;
using System.Text;

namespace TbcBank.EcommerceClient
{
    public static class TransactionResultStatus
    {
        /// <summary>
        /// successfully completed transaction, FAILED – transaction has failed,
        /// </summary>
        public const string OK = "OK";
        /// <summary>
        /// transaction just registered in the system, PENDING – transaction is not accomplished yet
        /// </summary>
        public const string CREATED = "CREATED";
        /// <summary>
        /// transaction declined by ECOMM, because ECI is in blocked ECI list(ECOMMserver side configuration)
        /// </summary>
        public const string DECLINED = "DECLINED";
        /// <summary>
        /// transaction is reversed
        /// </summary>    
        public const string REVERSED = "REVERSED";
        /// <summary>
        /// transaction is reversed by autoreversal, TIMEOUT – transaction was timed out
        /// </summary>
        public const string AUTOREVERSED = "AUTOREVERSED";
        /// <summary>
        /// successfully completed payment, CANCELLED – cancelled payment, RETURNED – returned payment,
        /// </summary>
        public const string FINISHED = "FINISHED";
        /// <summary>
        /// registered and not yet completed payment.
        /// </summary>
        public const string ACTIVE = "ACTIVE";
    }
}
