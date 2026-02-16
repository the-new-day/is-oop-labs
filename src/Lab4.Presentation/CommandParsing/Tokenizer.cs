using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Results;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing;

public class Tokenizer
{
    public TokenizingResult Tokenize(string input)
    {
        string[] parts = input.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        List<string> arguments = new();
        Dictionary<string, string> flags = new();

        for (int i = 0; i < parts.Length; i++)
        {
            if (parts[i].StartsWith('-'))
            {
                if (parts.Length == i + 1)
                {
                    return new TokenizingResult.Failure($"No value provided for the flag: {parts[i]}");
                }

                string value = parts[i + 1];
                flags[parts[i].Substring(1)] = value;

                i++;
                continue;
            }

            arguments.Add(parts[i]);
        }

        var tokens = new CommandTokens(
            new ReadOnlyCollection<string>(arguments),
            new ReadOnlyDictionary<string, string>(flags));

        return new TokenizingResult.Success(tokens);
    }
}
