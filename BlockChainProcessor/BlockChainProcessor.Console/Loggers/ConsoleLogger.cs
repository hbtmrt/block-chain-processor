using System;

namespace BlockChainProcessor.App.Loggers
{
    public sealed class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}