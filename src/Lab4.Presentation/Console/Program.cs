using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Console.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Console;

public class Program
{
    public static void Main()
    {
        List<string> availableCommands = [
            "connect", "disconnect", "file copy", "file delete",
            "file move", "file rename", "file show", "tree goto", "tree list",
        ];
        var commandParser = new ConsoleCommandParser(availableCommands);

        System.Console.WriteLine("File System. Waiting for you command...");

        while (true)
        {
            string? input = System.Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                continue;
            }

            CommandParsingResult parsingResult = commandParser.Parse(input);

            if (parsingResult is CommandParsingResult.EmptyCommand)
                continue;

            if (parsingResult is CommandParsingResult.Success command)
            {
                System.Console.Write("Name: ");
                System.Console.WriteLine(command.ParsedCommand.CommandName);

                System.Console.WriteLine("Parameters:");
                foreach ((int name, string value) in command.ParsedCommand.Parameters)
                {
                    System.Console.Write("    ");
                    System.Console.WriteLine($"[{name}] = \"{value}\"");
                }

                System.Console.WriteLine("Flags:");
                foreach ((string name, string value) in command.ParsedCommand.Flags)
                {
                    System.Console.Write("    ");
                    System.Console.WriteLine($"[{name}] = \"{value}\"");
                }

                continue;
            }

            if (parsingResult is CommandParsingResult.NoTokensFound)
            {
                System.Console.WriteLine("No tokens found in input");
                continue;
            }

            if (parsingResult is CommandParsingResult.UnknownCommand unknownCommand)
            {
                System.Console.WriteLine($"Unknown command '{unknownCommand.CommandName}'");
            }
        }
    }
}
