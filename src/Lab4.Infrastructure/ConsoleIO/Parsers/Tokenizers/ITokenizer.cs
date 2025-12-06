namespace Itmo.ObjectOrientedProgramming.Lab4.Infrastructure.ConsoleIO.Parsers.Tokenizers;

public interface ITokenizer
{
    IEnumerable<string> Tokenize(string input);
}
