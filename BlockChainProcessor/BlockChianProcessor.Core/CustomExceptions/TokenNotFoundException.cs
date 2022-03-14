using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChianProcessor.Core.CustomExceptions
{
    /// <summary>
    /// To handle when trying deleting a token but the token does not exist.
    /// </summary>
    public sealed class TokenNotFoundException : Exception
    {
        public TokenNotFoundException(string message) : base(message)
        {
        }
    }
}
