using System;

namespace BlockChianProcessor.Core.CustomExceptions
{
    /// <summary>
    /// Used when there are some issues with the deserialization, may be data curruption.
    /// </summary>
    public class BCDeserializatoinException : Exception
    {
        public BCDeserializatoinException(string message) : base(message)
        {
        }
    }
}