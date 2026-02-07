using Itmo.ObjectOrientedProgramming.Lab4.Core;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Results;
using Directory = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.Directory;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Parsers;

public class TreeGotoParser : ParserHandler
{
    private readonly IFileSystemConnection _connection;

    public TreeGotoParser(IFileSystemConnection connection)
    {
        _connection = connection;
    }

    public override CommandParsingResult TryParse(CommandTokens tokens)
    {
        if (tokens.Arguments.Count < 2)
            return CallNext(tokens);

        if (tokens.Arguments.ElementAt(0) != "tree" || tokens.Arguments.ElementAt(1) != "goto")
            return CallNext(tokens);

        if (tokens.Arguments.Count < 3)
            return new CommandParsingResult.Failure("Path required");

        string path = tokens.Arguments.ElementAt(2);

        return new CommandParsingResult.CommandCreated(
            new TreeGotoCommand(_connection, new Directory(path)));
    }
}
