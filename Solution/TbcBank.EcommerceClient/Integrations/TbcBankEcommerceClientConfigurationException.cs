﻿using System;
using System.Runtime.Serialization;

namespace Microsoft.Extensions.Configuration
{
    [Serializable]
    internal class TbcBankEcommerceClientConfigurationException : Exception
    {
        public TbcBankEcommerceClientConfigurationException()
        {
        }

        public TbcBankEcommerceClientConfigurationException(string message) : base(message)
        {
        }

        public TbcBankEcommerceClientConfigurationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TbcBankEcommerceClientConfigurationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}