using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Results;
using File = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Parsers;

public class FileDeleteParser : CommandLeafParser
{
    protected override CommandParsingResult BuildCommand(CommandTokens tokens)
    {
        if (tokens.Arguments.Count == 0)
            return new CommandParsingResult.Failure("Path required");

        string path = tokens.Arguments.ElementAt(0);

        return new CommandParsingResult.CommandCreated(
            new FileDeleteCommand(new File(path)));
    }
}
