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
        #region Declarations

        private static readonly Mutex singleton = new(true, Constants.ApplicationGuid);
        private static readonly ILogger logger = LoggerFactory.CreateLogger();
        private static readonly CancellationTokenSource cancellationTokenSource = new();
        private static readonly FileHelper fileHelper = new();
        private static BlockChain blockChain = new();

        #endregion Declarations

        #region Constructor

        private static void Main(string[] args)
        {
            if (!singleton.WaitOne(TimeSpan.Zero, true))
            {
                //there is already another instance running!
                // prevent having more than one instances.
                Environment.Exit(0);
            }

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

                    fileHelper.Persist(blockChain);
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

        #endregion Constructor

        #region Methods

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

        #endregion Methods
    }
}