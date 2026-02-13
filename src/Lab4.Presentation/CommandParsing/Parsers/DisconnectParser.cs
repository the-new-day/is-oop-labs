using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Parsers;

public class DisconnectParser : CommandLeafParser
{
    protected override CommandParsingResult BuildCommand(CommandTokens tokens)
    {
        return new CommandParsingResult.Disconnect();
    }
}
