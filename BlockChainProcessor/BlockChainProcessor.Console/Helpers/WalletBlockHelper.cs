using System.Linq;
using BlockChianProcessor.Core.Models;

namespace BlockChainProcessor.App.Helpers
{
    /// <summary>
    /// A helper to deal with wallets.
    /// </summary>
    public sealed class WalletBlockHelper
    {
        public WalletBlock GetByToken(BlockChain blockChain, string tokenId)
        {
            return blockChain.Chain.FirstOrDefault(block => block.Tokens.Any(token => token.TokenId.Equals(tokenId)));
        }
    }
}