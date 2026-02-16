using Itmo.ObjectOrientedProgramming.Lab4.Core;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Results;
using Directory = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.Directory;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Parsers;

public class TreeGotoParser : CommandLeafParser
{
    private readonly IFileSystemConnection _connection;

    public TreeGotoParser(IFileSystemConnection connection)
    {
        _connection = connection;
    }

    protected override CommandParsingResult BuildCommand(CommandTokens tokens)
    {
        if (tokens.Arguments.Count == 0)
            return new CommandParsingResult.Failure("Path required");

        string path = tokens.Arguments.ElementAt(0);

        return new CommandParsingResult.CommandCreated(
            new TreeGotoCommand(_connection, new Directory(path)));
    }
}
