using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Results;
using File = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Parsers;

public class FileShowParser : ParserHandler
{
    private readonly Dictionary<string, IFileContentDisplayer> _supportedModes;

    public FileShowParser(Dictionary<string, IFileContentDisplayer> supportedModes)
    {
        _supportedModes = supportedModes;
    }

    public override CommandParsingResult TryParse(CommandTokens tokens)
    {
        if (tokens.Arguments.Count < 2)
            return CallNext(tokens);

        if (tokens.Arguments[0] != "file" || tokens.Arguments[1] != "show")
            return CallNext(tokens);

        if (tokens.Arguments.Count < 3)
            return new CommandParsingResult.Failure("Path required");

        if (!tokens.Flags.TryGetValue("m", out string? mode))
            return new CommandParsingResult.Failure("Mode required");

        string path = tokens.Arguments[2];

        if (!_supportedModes.TryGetValue(mode, out IFileContentDisplayer? displayer))
            return new CommandParsingResult.Failure("Unsupported mode provided");

        return new CommandParsingResult.CommandCreated(
            new FileShowCommand(new File(path), displayer));
    }
}
