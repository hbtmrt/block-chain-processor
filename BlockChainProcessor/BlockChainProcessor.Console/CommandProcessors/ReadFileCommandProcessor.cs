using System.Collections.Generic;
using System.IO;
using BlockChainProcessor.App.Helpers;
using BlockChianProcessor.Core.CustomExceptions;
using BlockChianProcessor.Core.Models;

namespace BlockChainProcessor.App.CommandProcessors
{
    public class ReadFileCommandProcessor : ICommandProcessor
    {
        private readonly TransactionHelper helper = new();

        public string Excecute(BlockChain blockChain, string parameterString)
        {
            if (!File.Exists(parameterString))
            {
                throw new BCFileNotExistException();
            }

            using StreamReader reader = new(parameterString);
            string content = reader.ReadToEnd();

            List<Transaction> transactions = new JsonReaderHelper().Deserialize<List<Transaction>>(content);
            string message = helper.Excecute(blockChain, transactions);
            blockChain.AddTransactions(transactions);

            return message;
        }
    }
}