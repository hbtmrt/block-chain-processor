using System;

namespace BlockChianProcessor.Core.CustomExceptions
{
    public sealed class TokenExistException : Exception
    {
        public TokenExistException(string message) : base(message)
        {
        }
    }
}