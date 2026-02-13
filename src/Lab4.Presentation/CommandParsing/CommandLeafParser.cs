using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing;

public abstract class CommandLeafParser : ParserHandler
{
    public override CommandParsingResult TryParse(CommandTokens tokens)
    {
        return BuildCommand(tokens);
    }

    protected abstract CommandParsingResult BuildCommand(CommandTokens tokens);
}
