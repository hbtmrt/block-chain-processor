using System;
using System.Linq;
using BlockChianProcessor.Core.CustomExceptions;
using BlockChianProcessor.Core.Models;
using BlockChianProcessor.Core.Statics;

namespace BlockChainProcessor.App.TransactionExcecutors
{
    public sealed class TransferTransactionExcecutor : ITransactionExcecutor
    {
        public bool Excecute(BlockChain blockChain, Transaction transaction)
        {
            WalletBlock fromWallet = blockChain.Chain.SingleOrDefault(block => block.Address.Equals(transaction.From));

            if (fromWallet == null)
            {
                throw new WalletNotFoundException(string.Format(Constants.Message.Error.WalletNotFound, transaction.From));
            }

            Token token = fromWallet.Tokens.SingleOrDefault(t => t.TokenId.Equals(transaction.TokenId));

            if (token == null)
            {
                throw new TokenNotFoundException(string.Format(Constants.Message.Error.TokenNotExist, transaction.TokenId));
            }

            WalletBlock toWallet = blockChain.Chain.SingleOrDefault(block => block.Address.Equals(transaction.To));

            if (fromWallet == null)
            {
                throw new WalletNotFoundException(string.Format(Constants.Message.Error.WalletNotFound, transaction.To));
            }

            try
            {
                fromWallet.Tokens.Remove(token);
                toWallet.Tokens.Add(token);

                blockChain.AddTransaction(transaction);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}