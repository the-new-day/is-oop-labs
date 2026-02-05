using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete;
using Itmo.ObjectOrientedProgramming.Lab4.Core.State;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Results;
using Directory = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.Directory;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Parsers;

public class TreeGotoParser : ParserHandler
{
    private readonly IConnection _connection;

    public TreeGotoParser(IConnection connection)
    {
        _connection = connection;
    }

    protected override CommandParsingResult TryParse(CommandTokens tokens)
    {
        if (tokens.Arguments.Count < 2)
            return CallNext(tokens);

        if (tokens.Arguments[0] != "tree" || tokens.Arguments[1] != "goto")
            return CallNext(tokens);

        if (tokens.Arguments.Count < 3)
            return new CommandParsingResult.Failure("Path required");

        string path = tokens.Arguments[2];

        return new CommandParsingResult.CommandCreated(
            new TreeGotoCommand(_connection, new Directory(path)));
    }
}
