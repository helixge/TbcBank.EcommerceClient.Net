using System;
using System.Collections.Generic;
using System.Text;

namespace TbcBank.EcommerceClient
{
    public static class _3DSecureStatus
    {
        /// <summary>
        /// successful 3D Secure authorization
        /// </summary>
        public const string AUTHENTICATED = "AUTHENTICATED";
        /// <summary>
        /// failed 3D Secure authorization
        /// </summary>
        public const string DECLINED = "DECLINED";
        /// <summary>
        /// cardholder is not a member of 3D Secure scheme NO_RANGE – card is not in 3D secure card range defined by issuer
        /// </summary>
        public const string NOTPARTICIPATED = "NOTPARTICIPATED";
        /// <summary>
        /// cardholder 3D secure authorization using attempts ACS server
        /// </summary>
        public const string ATTEMPTED = "ATTEMPTED";
        /// <summary>
        ///  cardholder 3D secure authorization is unavailable
        /// </summary>
        public const string UNAVAILABLE = "UNAVAILABLE";
        /// <summary>
        /// error message received from ACS server
        /// </summary>
        public const string ERROR = "ERROR";
        /// <summary>
        /// 3D secure authorization ended with system error
        /// </summary>
        public const string SYSERROR = "SYSERROR";
        /// <summary>
        /// 3D  secure authorization  was attempted by wrong  card scheme(Dinners club, American Express)
        /// </summary>
        public const string UNKNOWNSCHEME = "UNKNOWNSCHEME";

    }
}
