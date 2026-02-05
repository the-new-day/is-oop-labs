using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation;

public class Program
{
    public static void Main()
    {
        var tokenizer = new Tokenizer();
        StartRepl(tokenizer);
    }

    private static void StartRepl(Tokenizer tokenizer)
    {
        while (true)
        {
            Console.Write("> ");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input)) continue;

            TokenizingResult result = tokenizer.Tokenize(input);
            switch (result)
            {
                case TokenizingResult.Success success:
                    PrintTokens(success.Tokens);
                    break;
                case TokenizingResult.Failure failure:
                    PrintError(failure.Message);
                    break;
            }
        }
    }

    private static void PrintTokens(CommandTokens tokens)
    {
        Console.WriteLine("Arguments:");
        foreach (string arg in tokens.Arguments)
        {
            Console.WriteLine($"\t{arg}");
        }

        Console.WriteLine("Flags:");
        foreach ((string? name, string? value) in tokens.Flags)
        {
            Console.WriteLine($"\t{name}: {value}");
        }
    }

    private static void PrintError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Error: {message}");
        Console.ResetColor();
    }
}
