using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Results;
using File = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Parsers;

public class FileShowParser : CommandLeafParser
{
    private readonly Dictionary<string, IFileContentDisplayer> _supportedModes;

    public FileShowParser(Dictionary<string, IFileContentDisplayer> supportedModes)
    {
        _supportedModes = supportedModes;
    }

    protected override CommandParsingResult BuildCommand(CommandTokens tokens)
    {
        if (tokens.Arguments.Count == 0)
            return new CommandParsingResult.Failure("Path required");

        if (!tokens.Flags.TryGetValue("m", out string? mode))
            return new CommandParsingResult.Failure("Mode required");

        if (!_supportedModes.TryGetValue(mode, out IFileContentDisplayer? displayer))
            return new CommandParsingResult.Failure("Unsupported mode provided");

        string path = tokens.Arguments.ElementAt(0);

        return new CommandParsingResult.CommandCreated(
            new FileShowCommand(new File(path), displayer));
    }
}
