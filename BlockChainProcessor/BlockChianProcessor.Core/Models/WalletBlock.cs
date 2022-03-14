using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BlockChianProcessor.Core.Models
{
    public sealed class WalletBlock
    {
        public string Address { get; set; }
        public List<Token> Tokens { get; set; }
        public int Index { get; set; }
        public DateTime TimeStamp { get; set; }
        public string PreviousHash { get; set; }
        public string Hash { get; set; }

        private readonly List<Transaction> _transactions;

        public WalletBlock(DateTime timeStamp, string previousHash, string address)
        {
            Index = 0;
            TimeStamp = timeStamp;
            PreviousHash = previousHash;
            Hash = CalculateHash();
            Address = address;

            Tokens = new();
            _transactions = new();
        }

        public void AddTransaction(Transaction transaction)
        {
            this._transactions.Add(transaction);
        }

        private string CalculateHash()
        {
            SHA256 sha256 = SHA256.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes($"{TimeStamp}-{PreviousHash ?? ""}-{Address}");
            byte[] outputBytes = sha256.ComputeHash(inputBytes);

            return Convert.ToBase64String(outputBytes);
        }


    }
}