using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem
{
    class CommandParser
    {
        public static CommandParameters Parse(string input)
        {
            int firstWhitespaceIndex = input.IndexOf(' ');
            if (firstWhitespaceIndex == -1)
            {
                throw new Exception("Invalid command: " + input);
            }

            string commandName = input.Substring(0, firstWhitespaceIndex);
            string commandArgs = input.Substring(firstWhitespaceIndex + 1);

            var commandArguments = ExtractCommandArgs(commandArgs);

            var command = new CommandParameters 
            {                 
                CommandName = commandName,
                Params = commandArguments
            };

            return command;
        }
 
        private static string[] ExtractCommandArgs(string commandArgs)
        {
            var commandArguments = commandArgs.Split('|');
            for (int i = 0; i < commandArguments.Length; i++)
            {
                commandArgs = commandArguments[i];
                commandArguments[i] = commandArgs.Trim();
            }
            return commandArguments;
        }
    }
}
