using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab4.Infrastructure.ConsoleIO.Parsers.Tokenizers;

public class CommandTokenizer : ITokenizer
{
    public IEnumerable<string> Tokenize(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            yield break;

        var currentToken = new StringBuilder();
        bool inQuotes = false;
        bool escapeNext = false;

        foreach (char ch in input)
        {
            if (escapeNext)
            {
                currentToken.Append(ch);
                escapeNext = false;
                continue;
            }

            if (ch == '\\')
            {
                escapeNext = true;
                continue;
            }

            if (ch == '"')
            {
                inQuotes = !inQuotes;
                continue;
            }

            if (ch == ' ' && !inQuotes)
            {
                if (currentToken.Length > 0)
                {
                    yield return currentToken.ToString();
                    currentToken.Clear();
                }

                continue;
            }

            currentToken.Append(ch);
        }

        if (currentToken.Length > 0)
        {
            yield return currentToken.ToString();
        }
    }
}
