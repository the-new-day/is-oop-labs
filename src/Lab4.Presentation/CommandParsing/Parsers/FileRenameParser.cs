using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Results;
using File = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Parsers;

public class FileRenameParser : CommandLeafParser
{
    protected override CommandParsingResult BuildCommand(CommandTokens tokens)
    {
        if (tokens.Arguments.Count < 2)
            return new CommandParsingResult.Failure("Path and Name required");

        string path = tokens.Arguments.ElementAt(0);
        string name = tokens.Arguments.ElementAt(1);

        return new CommandParsingResult.CommandCreated(
            new FileRenameCommand(new File(path), name));
    }
}
