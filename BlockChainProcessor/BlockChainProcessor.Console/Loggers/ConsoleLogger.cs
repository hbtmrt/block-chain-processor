using System;

namespace BlockChainProcessor.App.Loggers
{
    /// <summary>
    /// A concrete logger writes to console.
    /// </summary>
    public sealed class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}