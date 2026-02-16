using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Results;
using Directory = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.Directory;
using File = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Parsers;

public class FileMoveParser : CommandLeafParser
{
    protected override CommandParsingResult BuildCommand(CommandTokens tokens)
    {
        if (tokens.Arguments.Count < 2)
            return new CommandParsingResult.Failure("Source and Destination required");

        string source = tokens.Arguments.ElementAt(0);
        string dest = tokens.Arguments.ElementAt(1);

        return new CommandParsingResult.CommandCreated(
            new FileMoveCommand(new File(source), new Directory(dest)));
    }
}
