using BlockChianProcessor.Core.Statics;

namespace BlockChianProcessor.Core.Models
{
    /// <summary>
    /// The transaction model.
    /// </summary>
    public sealed class Transaction
    {
        public TransactionType Type { get; set; }
        public string TokenId { get; set; }
        public string Address { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
}