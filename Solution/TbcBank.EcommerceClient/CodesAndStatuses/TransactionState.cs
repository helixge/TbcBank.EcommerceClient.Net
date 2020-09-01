using System;
using System.Collections.Generic;
using System.Text;

namespace TbcBank.EcommerceClient
{
    public enum TransactionState
    {
        Unknown = 0,
        Pending = 1,
        Succeeded = 2,
        Failed = 3
    }
}
