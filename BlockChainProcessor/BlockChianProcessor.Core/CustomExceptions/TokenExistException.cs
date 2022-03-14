using System;

namespace BlockChianProcessor.Core.CustomExceptions
{
    /// <summary>
    /// To handle when trying to add a token but it already exists.
    /// </summary>
    public sealed class TokenExistException : Exception
    {
        public TokenExistException(string message) : base(message)
        {
        }
    }
}