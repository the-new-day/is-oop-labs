namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing;

public class Tokenizer
{
    public CommandTokens Tokenize(string input)
    {
        string[] parts = input.Trim().Split(' ');
        List<string> arguments = new();
        Dictionary<string, string> flags = new();

        for (int i = 0; i < parts.Length; i++)
        {
            if (parts[i].StartsWith('-'))
            {
                if (parts.Length == i + 1)
                {
                    throw new ArgumentException("No value provided for the flag: " + parts[0], nameof(input));
                }

                string value = parts[i + 1];
                flags.Add(parts[i].Substring(1), value);

                i++;
                continue;
            }

            arguments.Add(parts[i]);
        }

        return new CommandTokens(arguments, flags);
    }
}
