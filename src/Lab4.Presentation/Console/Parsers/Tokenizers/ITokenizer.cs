namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Console.Parsers.Tokenizers;

public interface ITokenizer
{
    IEnumerable<string> Tokenize(string input);
}
