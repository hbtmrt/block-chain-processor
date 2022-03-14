using System;
using System.Collections.Generic;
using BlockChianProcessor.Core.Models;

namespace BlockChainProcessor.App
{
    /// <summary>
    /// The block-chain implementation.
    /// </summary>
    public sealed class BlockChain
    {
        public List<WalletBlock> Chain { set; get; }
        public List<Transaction> Transactions { get; set; }

        public BlockChain()
        {
            Chain = new();
            Transactions = new();

            AddGenesisBlock();
        }

        public WalletBlock LastBlock => Chain[^1];

        public void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
        }

        public void AddTransactions(List<Transaction> transactions)
        {
            transactions.ForEach(transaction =>
            {
                AddTransaction(transaction);
            });
        }

        private void AddGenesisBlock()
        {
            Chain.Add(CreateGenesisBlock);
        }

        private WalletBlock CreateGenesisBlock => new(DateTime.Now, null, Guid.NewGuid().ToString());
    }
}