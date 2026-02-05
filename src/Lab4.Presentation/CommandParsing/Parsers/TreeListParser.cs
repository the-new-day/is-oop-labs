using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Results;
using Directory = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.Directory;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Parsers;

public class TreeListParser : ParserHandler
{
    private readonly Directory _path;

    private readonly ITreeListDisplayer _displayer;

    public TreeListParser(Directory path, ITreeListDisplayer displayer)
    {
        _path = path;
        _displayer = displayer;
    }

    protected override CommandParsingResult TryParse(CommandTokens tokens)
    {
        if (tokens.Arguments.Count < 2)
            return CallNext(tokens);

        if (tokens.Arguments[0] != "tree" || tokens.Arguments[1] != "list")
            return CallNext(tokens);

        if (tokens.Arguments.Count < 3 || !tokens.Flags.ContainsKey("d"))
            return new CommandParsingResult.Failure("Depth required");

        string rawDepth = tokens.Arguments[2];
        int depth = 1; // TODO: parse flag

        return new CommandParsingResult.CommandCreated(
            new TreeListCommand(_path, depth, _displayer));
    }
}
