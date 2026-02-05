using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation;

public class Program
{
    public static void Main()
    {
        var tokenizer = new Tokenizer();
        CommandTokens tokens = tokenizer.Tokenize("connect / -m local");

        Console.WriteLine("Arguments:");
        foreach (string arg in tokens.Arguments)
        {
            Console.WriteLine($"\t{arg}");
        }

        Console.WriteLine("Flags:");
        foreach (var (name, value) in tokens.Flags)
        {
            Console.WriteLine($"\t{name}: {value}");
        }
    }
}
