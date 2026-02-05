namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Parsers;

public class TreeListParser : ParserHandler
{
    private readonly Nodes.Directory _path;

    private readonly ITreeListDisplayer _displayer;

    public TreeListParser(Nodes.Directory path, ITreeListDisplayer displayer)
    {
        _path = path;
        _displayer = displayer;
    }

    protected override ICommand? TryParse(CommandTokens args)
    {
        if (tokens.Arguments.Count < 2) return null;
        if (tokens.Arguments[0] != "tree" || tokens.Arguments[1] != "list") return null;

        if (tokens.Arguments.Count < 3) // TODO: check if "-d" exists
            throw new ArgumentException("Depth required");

        string rawDepth = tokens.Arguments[2];
        int depth = 1; // TODO: parse flag

        return new TreeListCommand(_path, depth, _displayer);
    }
}
