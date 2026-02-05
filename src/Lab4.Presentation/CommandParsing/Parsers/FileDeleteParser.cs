using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Results;
using File = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Parsers;

public class FileDeleteParser : ParserHandler
{
    protected override CommandParsingResult TryParse(CommandTokens tokens)
    {
        if (tokens.Arguments.Count < 2)
            return CallNext(tokens);

        if (tokens.Arguments[0] != "file" || tokens.Arguments[1] != "delete")
            return CallNext(tokens);

        if (tokens.Arguments.Count < 3)
            return new CommandParsingResult.Failure("Path required");

        string path = tokens.Arguments[2];

        return new CommandParsingResult.CommandCreated(
            new FileDeleteCommand(new File(path)));
    }
}
