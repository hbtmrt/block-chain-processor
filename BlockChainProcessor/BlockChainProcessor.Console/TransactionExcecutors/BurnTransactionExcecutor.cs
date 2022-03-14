using System;
using System.Linq;
using BlockChainProcessor.App.Helpers;
using BlockChianProcessor.Core.CustomExceptions;
using BlockChianProcessor.Core.Models;
using BlockChianProcessor.Core.Statics;

namespace BlockChainProcessor.App.TransactionExcecutors
{
    /// <summary>
    /// Implements Burn transaction related functions.
    /// </summary>
    public sealed class BurnTransactionExcecutor : ITransactionExcecutor
    {
        private readonly WalletBlockHelper blockHelper = new();

        public bool Excecute(BlockChain blockChain, Transaction transaction)
        {
            WalletBlock block = blockHelper.GetByToken(blockChain, transaction.TokenId);

            if (block == null)
            {
                throw new TokenNotFoundException(string.Format(Constants.Message.Error.TokenNotExist, transaction.TokenId));
            }

            try
            {
                block.Tokens.Remove(block.Tokens.Single(token => token.TokenId.Equals(transaction.TokenId)));
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