using System.Linq;

namespace BlockChainProcessor.App.Helpers
{
    public sealed class TokenHelper
    {
        internal bool Exist(BlockChain blockChain, string tokenId)
        {
            return blockChain.Chain.SelectMany(block => block.Tokens).Any(token => token.TokenId.Equals(tokenId));
        }
    }
}