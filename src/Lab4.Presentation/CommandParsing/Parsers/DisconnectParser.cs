using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Parsers;

public class DisconnectParser : ParserHandler
{
    public override CommandParsingResult TryParse(CommandTokens tokens)
    {
        if (tokens.Arguments[0] == "disconnect")
            return new CommandParsingResult.Disconnect();

        return CallNext(tokens);
    }
}
