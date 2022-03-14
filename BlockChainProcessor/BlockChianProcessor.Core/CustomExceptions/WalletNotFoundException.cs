using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChianProcessor.Core.CustomExceptions
{
    /// <summary>
    /// To handle wallet not found situations.
    /// </summary>
    public sealed class WalletNotFoundException : Exception
    {
        public WalletNotFoundException(string message) : base(message)
        {
        }
    }
}
