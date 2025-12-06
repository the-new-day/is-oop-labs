using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Infrastructure.ConsoleIO.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Infrastructure.ConsoleIO;

public class Program
{
    public static void Main()
    {
        List<string> availableCommands = [
            "connect", "disconnect", "file copy", "file delete",
            "file move", "file rename", "file show", "tree goto", "tree list",
        ];
        var commandParser = new ConsoleCommandParser(availableCommands);

        Console.WriteLine("File System. Waiting for you command...");

        while (true)
        {
            string? input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                continue;
            }

            CommandParsingResult parsingResult = commandParser.Parse(input);

            if (parsingResult is CommandParsingResult.EmptyCommand)
                continue;

            if (parsingResult is CommandParsingResult.Success command)
            {
                Console.Write("Name: ");
                Console.WriteLine(command.ParsedCommand.CommandName);

                Console.WriteLine("Parameters:");
                foreach ((int name, string value) in command.ParsedCommand.Parameters)
                {
                    Console.Write("    ");
                    Console.WriteLine($"[{name}] = \"{value}\"");
                }

                Console.WriteLine("Flags:");
                foreach ((string name, string value) in command.ParsedCommand.Flags)
                {
                    Console.Write("    ");
                    Console.WriteLine($"[{name}] = \"{value}\"");
                }

                continue;
            }

            if (parsingResult is CommandParsingResult.NoTokensFound)
            {
                Console.WriteLine("No tokens found in input");
                continue;
            }

            if (parsingResult is CommandParsingResult.UnknownCommand unknownCommand)
            {
                Console.WriteLine($"Unknown command '{unknownCommand.CommandName}'");
            }
        }
    }
}
