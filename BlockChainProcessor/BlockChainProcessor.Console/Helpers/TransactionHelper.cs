using System.Collections.Generic;
using BlockChainProcessor.App.Factories;
using BlockChainProcessor.App.TransactionExcecutors;
using BlockChianProcessor.Core.Models;
using BlockChianProcessor.Core.Statics;

namespace BlockChainProcessor.App.Helpers
{
    /// <summary>
    /// A helper to deal with transactions.
    /// </summary>
    public sealed class TransactionHelper
    {
        internal string Excecute(BlockChain blockChain, List<Transaction> transactions)
        {
            int transactionCount = 0;
            transactions.ForEach(transaction =>
            {
                ITransactionExcecutor excecutor = TransactionExcecutorFactory.CreateInstance(transaction.Type);

                if (excecutor.Excecute(blockChain, transaction))
                {
                    transactionCount++;
                }
            });

            return string.Format(Constants.Message.MintSuccessfulFormat, transactionCount);
        }
    }
}