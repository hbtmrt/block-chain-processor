using System;
using BlockChianProcessor.Core.CustomExceptions;

namespace BlockChianProcessor.Core.Models
{
    public sealed class BCCommand
    {
        public string Command { get; set; }
        public string Parameters { get; set; }

        public BCCommand(string argument)
        {
            Command = GetCommandString(argument);
            Parameters = GetParameterString(argument);
        }

        private string GetCommandString(string commandArgument)
        {
            try
            {
                return commandArgument.Split("program --")[1].Split(" ")[0].Trim();
            }
            catch (Exception)
            {
                throw new InvalidCommandException();
            }
        }

        private string GetParameterString(string commandArgument)
        {
            try
            {
                return commandArgument.Split($"program --{GetCommandString(commandArgument)}")[1].Replace("\'", "").Trim();
            }
            catch (Exception)
            {
                throw new InvalidCommandException();
            }
        }
    }
}