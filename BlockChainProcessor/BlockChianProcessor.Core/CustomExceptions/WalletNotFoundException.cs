using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChianProcessor.Core.CustomExceptions
{
    public sealed class WalletNotFoundException : Exception
    {
        public WalletNotFoundException(string message) : base(message)
        {
        }
    }
}
