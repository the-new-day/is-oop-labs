namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Parsers;

public class FileRenameParser : ParserHandler
{
    protected override ICommand? TryParse(CommandTokens args)
    {
        if (tokens.Arguments.Count < 2) return null;
        if (tokens.Arguments[0] != "file" || tokens.Arguments[1] != "rename") return null;

        if (tokens.Arguments.Count < 4)
            throw new ArgumentException("Path and Name required");

        string path = tokens.Arguments[2];
        string name = tokens.Arguments[3];

        return new FileRenameCommand(new Nodes.File(path), name);
    }
}
