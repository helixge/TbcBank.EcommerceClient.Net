using System;
using System.Collections.Generic;
using System.Text;

namespace TbcBank.EcommerceClient
{
    public static class TbcBankEcommerceClientOptionsExtentions
    {
        public static void Validate(this IEnumerable<TbcBankEcommerceClientOptions> optionsList)
        {
            foreach (var options in optionsList)
                options.Validate();
        }
    }
}
