using System;
using System.Threading;
using BlockChainProcessor.App.CommandProcessors;
using BlockChainProcessor.App.Factories;
using BlockChainProcessor.App.Helpers;
using BlockChainProcessor.App.Loggers;
using BlockChianProcessor.Core.CustomExceptions;
using BlockChianProcessor.Core.Models;
using BlockChianProcessor.Core.Statics;

namespace BlockChainProcessor.App
{
    internal class Program
    {
        private static readonly ILogger logger = LoggerFactory.CreateLogger();
        private static readonly CancellationTokenSource cancellationTokenSource = new();
        private static readonly FileHelper fileHelper = new();
        private static BlockChain blockChain = new();

        private static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += (object sender, EventArgs e) => fileHelper.Persist(blockChain);

            logger.Log(Constants.Message.InitializingProgram);
            blockChain = fileHelper.Load();
            logger.Log(Constants.Message.Initialized);

            while (!cancellationTokenSource.IsCancellationRequested)
            {
                string commandArgument = Console.ReadLine();

                if (!IsValidCommand(commandArgument))
                {
                    logger.Log(Constants.Message.Error.InvalidCommand);
                    continue;
                }

                try
                {
                    BCCommand command = new(commandArgument);
                    ICommandProcessor commandProcessor = CommandProcessorFactory.CreateInstance(command.Command);
                    string message = commandProcessor.Excecute(blockChain, command.Parameters);
                    logger.Log(message);
                }
                catch (InvalidCommandException)
                {
                    logger.Log(Constants.Message.Error.InvalidCommand);
                }
                catch (Exception)
                {
                    logger.Log(Constants.Message.Error.InvalidCommand);
                }
            }
        }

        private static bool IsValidCommand(string commandArgument)
        {
            if (string.IsNullOrWhiteSpace(commandArgument))
            {
                logger.Log(Constants.Message.Error.NoArgumentProvided);
                return false;
            }

            if (!commandArgument.StartsWith("program"))
            {
                logger.Log(Constants.Message.Error.CommandShouldStartWithProgram);
                return false;
            }

            return true;
        }
    }
}