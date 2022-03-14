using BlockChianProcessor.Core.Models;

namespace BlockChainProcessor.App.TransactionExcecutors
{
    /// <summary>
    /// Defines methods related to transaction excecutors.
    /// </summary>
    public interface ITransactionExcecutor
    {
        bool Excecute(BlockChain blockChain, Transaction transaction);
    }
}