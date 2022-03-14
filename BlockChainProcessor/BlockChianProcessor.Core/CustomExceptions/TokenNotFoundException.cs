using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChianProcessor.Core.CustomExceptions
{
    public sealed class TokenNotFoundException : Exception
    {
        public TokenNotFoundException(string message) : base(message)
        {
        }
    }
}
