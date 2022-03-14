using BlockChainProcessor.App.TransactionExcecutors;
using BlockChianProcessor.Core.Statics;

namespace BlockChainProcessor.App.Factories
{
    public sealed class TransactionExcecutorFactory
    {
        public static ITransactionExcecutor CreateInstance(TransactionType type)
        {
            return type switch
            {
                TransactionType.Mint => new MintTransactionExcecutor(),
                TransactionType.Burn => new BurnTransactionExcecutor(),
                _ => new TransferTransactionExcecutor()
            };
        }
    }
}