using System;
using System.Collections.Generic;
using BlockChianProcessor.Core.Models;

namespace BlockChainProcessor.App
{
    public sealed class BlockChain
    {
        public List<WalletBlock> Chain { set; get; }
        private readonly List<Transaction> _transactions;

        public BlockChain()
        {
            Chain = new();
            _transactions = new();

            AddGenesisBlock();
        }

        public WalletBlock LastBlock => Chain[^1];

        public void AddTransaction(Transaction transaction)
        {
            _transactions.Add(transaction);
        }

        private void AddGenesisBlock()
        {
            Chain.Add(CreateGenesisBlock);
        }

        private WalletBlock CreateGenesisBlock => new(DateTime.Now, null, Guid.NewGuid().ToString());
    }
}