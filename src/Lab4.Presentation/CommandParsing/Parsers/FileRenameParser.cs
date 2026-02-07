using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Results;
using File = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Parsers;

public class FileRenameParser : ParserHandler
{
    public override CommandParsingResult TryParse(CommandTokens tokens)
    {
        if (tokens.Arguments.Count < 2)
            return CallNext(tokens);

        if (tokens.Arguments[0] != "file" || tokens.Arguments[1] != "rename")
            return CallNext(tokens);

        if (tokens.Arguments.Count < 4)
            return new CommandParsingResult.Failure("Path and Name required");

        string path = tokens.Arguments[2];
        string name = tokens.Arguments[3];

        return new CommandParsingResult.CommandCreated(
            new FileRenameCommand(new File(path), name));
    }
}
