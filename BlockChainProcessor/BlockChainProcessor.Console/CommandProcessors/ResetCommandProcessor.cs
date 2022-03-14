using BlockChianProcessor.Core.Statics;

namespace BlockChainProcessor.App.CommandProcessors
{
    public class ResetCommandProcessor : ICommandProcessor
    {
        public string Excecute(BlockChain blockChain, string parameterString)
        {
            blockChain.Chain.ForEach(block => block.Tokens.Clear());
            return Constants.Message.Reset;
        }
    }
}