using System;
using System.Collections.Generic;
using System.Text;

namespace TbcBank.EcommerceClient
{
    public static class TransactionResultStatus
    {
        /// <summary>
        /// successfully completed transaction
        /// </summary>
        public const string OK = "OK";
        /// <summary>
        /// FAILED – transaction has failed
        /// </summary>
        public const string FAILED = "FAILED";
        /// <summary>
        /// transaction just registered in the system
        /// </summary>
        public const string CREATED = "CREATED";
        /// <summary>
        /// PENDING – transaction is not accomplished yet
        /// </summary>
        public const string PENDING = "PENDING";
        /// <summary>
        /// transaction declined by ECOMM, because ECI is in blocked ECI list(ECOMMserver side configuration)
        /// </summary>
        public const string DECLINED = "DECLINED";
        /// <summary>
        /// transaction is reversed
        /// </summary>    
        public const string REVERSED = "REVERSED";
        /// <summary>
        /// transaction is reversed by autoreversal
        /// </summary>
        public const string AUTOREVERSED = "AUTOREVERSED";
        /// <summary>
        /// transaction was timed out
        /// </summary>
        public const string TIMEOUT = "TIMEOUT";
        /// <summary>
        /// successfully completed payment
        /// </summary>
        public const string FINISHED = "FINISHED";
        /// <summary>
        /// CANCELLED – cancelled payment
        /// </summary>
        public const string CANCELLED = "CANCELLED";
        /// <summary>
        /// RETURNED – returned payment
        /// </summary>
        public const string RETURNED = "RETURNED";
        /// <summary>
        /// registered and not yet completed payment.
        /// </summary>
        public const string ACTIVE = "ACTIVE";
    }
}
