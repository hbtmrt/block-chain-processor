namespace BlockChianProcessor.Core.Statics
{
    public static class Constants
    {
        public const string DataStoreFilePath = @"data-store.json";

        public static class Command
        {
            public const string ReadLine = "read-inline";
            public const string ReadFile = "read-file";
            public const string NftOwnership = "nft";
            public const string WalletOwnership = "wallet";
            public const string Reset = "reset";
        }

        public static class Message
        {
            public const string InitializingProgram = "Initializing program...";
            public const string Initialized = "Initialization completed, please type your commands...";
            public const string MintSuccessfulFormat = "Read {0} transaction(s)";
            public const string NftOwned = "Token {0} is owned by {1}.";
            public const string NftNotOwned = "Token {0} is not owned by any wallet.";
            public const string WalletHasTokens = "Wallet {0} holds {1} Tokens:";
            public const string WalletWithoutToken = "Wallet {0} holds no Tokens:";
            public const string Reset = "Program was reset.";

            public static class Error
            {
                public const string NoArgumentProvided = "Error. No arguments have been provided.";
                public const string InvalidCommand = "Invalid command. Try again...";
                public const string CommandShouldStartWithProgram = "Error. All commands should start with \"program\".";
                public const string CommonError = "Critical error. Please contact the administrator.";
                public const string NotAValidFilePath = "Error. The file path provided is not valid.";
                public const string FileNotExist = "Error. The file does not exist.";
                public const string ParameterFormatError = "Error. There is something wrong with the parameter string. Please check and try again.";
                public const string TokenExist = "Error. The token {0} already exist in the block chain.";
                public const string TokenNotExist = "Error. The token {0} not exist in the block chain.";
                public const string WalletNotFound = "Error. The wallet specified by the address {0} cannot be found.";
            }
        }
    }
}