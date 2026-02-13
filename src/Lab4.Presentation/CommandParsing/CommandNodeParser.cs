using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing;

public class CommandNodeParser : ParserHandler
{
    private readonly string _keyword;

    private readonly ParserHandler _innerChain;

    public CommandNodeParser(string keyword, ParserHandler innerChain)
    {
        _keyword = keyword;
        _innerChain = innerChain;
    }

    public override CommandParsingResult TryParse(CommandTokens tokens)
    {
        if (tokens.Arguments.Count == 0 || tokens.Arguments.ElementAt(0) != _keyword)
            return CallNext(tokens);

        var innerTokens = new CommandTokens(
            tokens.Arguments.Skip(1).ToList(),
            tokens.Flags);

        return _innerChain.TryParse(innerTokens);
    }
}
