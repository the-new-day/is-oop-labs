namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Parsers;

public class TreeGotoParser : ParserHandler
{
    private readonly IConnection _connection;

    public TreeGotoParser(IConnection connection)
    {
        _connection = connection;
    }

    protected override ICommand? TryParse(CommandTokens args)
    {
        if (tokens.Arguments.Count < 2) return null;
        if (tokens.Arguments[0] != "tree" || tokens.Arguments[1] != "goto") return null;

        if (tokens.Arguments.Count < 3)
            throw new ArgumentException("Path required");

        string path = tokens.Arguments[2];

        return new TreeGotoCommand(_connection, new Nodes.Directory(path));
    }
}
