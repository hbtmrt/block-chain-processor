using System.Linq;
using BlockChianProcessor.Core.Models;

namespace BlockChainProcessor.App.Helpers
{
    public sealed class WalletBlockHelper
    {
        public WalletBlock GetByToken(BlockChain blockChain, string tokenId)
        {
            return blockChain.Chain.FirstOrDefault(block => block.Tokens.Any(token => token.TokenId.Equals(tokenId)));
        }
    }
}