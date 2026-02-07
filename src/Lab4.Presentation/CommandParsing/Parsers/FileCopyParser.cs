using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Results;
using Directory = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.Directory;
using File = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Parsers;

public class FileCopyParser : ParserHandler
{
    public override CommandParsingResult TryParse(CommandTokens tokens)
    {
        if (tokens.Arguments.Count < 2)
            return CallNext(tokens);

        if (tokens.Arguments.ElementAt(0) != "file" || tokens.Arguments.ElementAt(1) != "copy")
            return CallNext(tokens);

        if (tokens.Arguments.Count < 4)
            return new CommandParsingResult.Failure("Source and Destination required");

        string source = tokens.Arguments.ElementAt(2);
        string dest = tokens.Arguments.ElementAt(3);

        return new CommandParsingResult.CommandCreated(
            new FileCopyCommand(new File(source), new Directory(dest)));
    }
}
