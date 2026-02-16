using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Results;
using Directory = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.Directory;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Parsers;

public class TreeListParser : CommandLeafParser
{
    private readonly ITreeListDisplayer _displayer;

    public TreeListParser(ITreeListDisplayer displayer)
    {
        _displayer = displayer;
    }

    protected override CommandParsingResult BuildCommand(CommandTokens tokens)
    {
        if (!tokens.Flags.TryGetValue("d", out string? value))
            return new CommandParsingResult.Failure("Depth required");

        if (!int.TryParse(value, out int depth))
            return new CommandParsingResult.Failure("Can't parse Depth: not an integer");

        return new CommandParsingResult.CommandCreated(
            new TreeListCommand(new Directory("."), depth, _displayer));
    }
}
