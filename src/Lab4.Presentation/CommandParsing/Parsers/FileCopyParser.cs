namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Parsers;

public class FileCopyParser : ParserHandler
{
    protected override ICommand? TryParse(CommandTokens args)
    {
        if (tokens.Arguments.Count < 2) return null;
        if (tokens.Arguments[0] != "file" || tokens.Arguments[1] != "copy") return null;

        if (tokens.Arguments.Count < 4)
            throw new ArgumentException("Source and Destination required");

        string source = tokens.Arguments[2];
        string dest = tokens.Arguments[3];

        return new FileCopyCommand(new Nodes.Directory(source), new Nodes.File(dest));
    }
}
