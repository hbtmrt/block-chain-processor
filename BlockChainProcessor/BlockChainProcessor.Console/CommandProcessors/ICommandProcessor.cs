namespace BlockChainProcessor.App.CommandProcessors
{
    /// <summary>
    /// Contains methods related to command processors.
    /// </summary>
    public interface ICommandProcessor
    {
        string Excecute(BlockChain blockChain, string parameterString);
    }
}