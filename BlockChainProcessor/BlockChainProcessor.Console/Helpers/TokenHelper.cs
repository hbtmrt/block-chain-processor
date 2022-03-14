using System.Linq;

namespace BlockChainProcessor.App.Helpers
{
    /// <summary>
    /// A helper to handle token related methods.
    /// </summary>
    public sealed class TokenHelper
    {
        public bool Exist(BlockChain blockChain, string tokenId)
        {
            return blockChain.Chain.SelectMany(block => block.Tokens).Any(token => token.TokenId.Equals(tokenId));
        }
    }
}