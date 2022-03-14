using System.Collections.Generic;
using BlockChainProcessor.App.Helpers;
using BlockChianProcessor.Core.Models;

namespace BlockChainProcessor.App.CommandProcessors
{
    /// <summary>
    /// Handles --read-inline operations.
    /// </summary>
    public class ReadLineCommandProcessor : ICommandProcessor
    {
        private readonly TransactionHelper helper = new();

        public string Excecute(BlockChain blockChain, string parameterString)
        {
            Transaction transaction = new JsonReaderHelper().Deserialize<Transaction>(parameterString);
            string message = helper.Excecute(blockChain, new List<Transaction>() { transaction });
            blockChain.AddTransaction(transaction);

            return message;
        }
    }
}