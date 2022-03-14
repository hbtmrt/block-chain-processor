using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlockChianProcessor.Core.Models;
using BlockChianProcessor.Core.Statics;

namespace BlockChainProcessor.App.CommandProcessors
{
    /// <summary>
    /// Handles --wallet operations.
    /// </summary>
    public class WalletOwnershipCommandProcessor : ICommandProcessor
    {
        public string Excecute(BlockChain blockChain, string parameterString)
        {
            string walletAddress = parameterString.Trim();
            WalletBlock block = blockChain.Chain.SingleOrDefault(b => b.Address.Equals(walletAddress));

            if (block == null)
            {
                return string.Format(Constants.Message.Error.WalletNotFound, walletAddress);
            }

            List<string> tokens = block.Tokens.Select(b => b.TokenId).ToList();

            if (tokens.Count == 0)
            {
                return string.Format(Constants.Message.WalletWithoutToken, parameterString);
            }

            StringBuilder sb = new(string.Format(Constants.Message.WalletHasTokens, parameterString, tokens.Count));
            tokens.ForEach(token =>
            {
                sb.AppendLine(token);
            });

            return sb.ToString();
        }
    }
}