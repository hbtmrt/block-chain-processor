using BlockChainProcessor.App.Loggers;

namespace BlockChainProcessor.App.Factories
{
    /// <summary>
    /// Resolves the type of the logger.
    /// </summary>
    public static class LoggerFactory
    {
        public static ILogger CreateLogger()
        {
            // In fture we can add more loggers apart from ConsoleLogger.
            return new ConsoleLogger();
        }
    }
}