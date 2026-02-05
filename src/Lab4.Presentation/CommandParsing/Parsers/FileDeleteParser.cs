using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Parsers;

public class FileDeleteParser : ParserHandler
{
    private readonly Nodes.Directory _path;

    public FileDeleteParser(Nodes.Directory path)
    {
        _path = path;
    }

    protected override ICommand? TryParse(CommandTokens args)
    {
        if (tokens.Arguments.Count < 2) return null;
        if (tokens.Arguments[0] != "file" || tokens.Arguments[1] != "delete") return null;

        if (tokens.Arguments.Count < 3)
            throw new ArgumentException("Path required");

        string path = tokens.Arguments[2];

        return new FileDeleteCommand(new Nodes.File(_path));
    }
}
