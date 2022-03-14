using System.Linq;
using BlockChianProcessor.Core.Models;
using BlockChianProcessor.Core.Statics;

namespace BlockChainProcessor.App.CommandProcessors
{
    /// <summary>
    /// Handles NFT operations.
    /// </summary>
    public class NftOwnershipCommandProcessor : ICommandProcessor
    {
        public string Excecute(BlockChain blockChain, string parameterString)
        {
            string tokenId = parameterString.Trim();
            WalletBlock block = blockChain.Chain.FirstOrDefault(b => b.Tokens.Any(token => token.TokenId.Equals(tokenId)));

            if (block == null)
            {
                return string.Format(Constants.Message.NftNotOwned, tokenId);
            }

            return string.Format(Constants.Message.NftOwned, parameterString, block.Address);
        }
    }
}