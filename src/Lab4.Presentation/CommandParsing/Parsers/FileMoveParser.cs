using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Results;
using Directory = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.Directory;
using File = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Parsers;

public class FileMoveParser : ParserHandler
{
    public override CommandParsingResult TryParse(CommandTokens tokens)
    {
        if (tokens.Arguments.Count < 2)
            return CallNext(tokens);

        if (tokens.Arguments[0] != "file" || tokens.Arguments[1] != "move")
            return CallNext(tokens);

        if (tokens.Arguments.Count < 4)
            return new CommandParsingResult.Failure("Source and Destination required");

        string source = tokens.Arguments[2];
        string dest = tokens.Arguments[3];

        return new CommandParsingResult.CommandCreated(
            new FileMoveCommand(new File(source), new Directory(dest)));
    }
}
