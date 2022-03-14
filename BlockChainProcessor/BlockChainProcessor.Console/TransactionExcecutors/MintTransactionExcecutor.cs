using System;
using System.Linq;
using BlockChainProcessor.App.Helpers;
using BlockChianProcessor.Core.CustomExceptions;
using BlockChianProcessor.Core.Models;
using BlockChianProcessor.Core.Statics;

namespace BlockChainProcessor.App.TransactionExcecutors
{
    /// <summary>
    /// Adds records to the wallets and blocks.
    /// </summary>
    public class MintTransactionExcecutor : ITransactionExcecutor
    {
        private readonly TokenHelper tokenHelper = new();

        public bool Excecute(BlockChain blockChain, Transaction transaction)
        {
            try
            {
                if (tokenHelper.Exist(blockChain, transaction.TokenId))
                {
                    throw new TokenExistException(string.Format(Constants.Message.Error.TokenExist, transaction.TokenId));
                }

                WalletBlock block = blockChain.Chain.FirstOrDefault(b => b.Address.Equals(transaction.Address));

                if (block == null)
                {
                    block = new(DateTime.Now, blockChain.LastBlock.Hash, transaction.Address);
                    blockChain.Chain.Add(block);
                }

                block.Tokens.Add(new Token { TokenId = transaction.TokenId });
                block.AddTransaction(transaction);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}