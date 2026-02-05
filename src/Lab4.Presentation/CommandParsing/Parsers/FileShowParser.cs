using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Parsers;

public class FileShowParser : ParserHandler
{
    private readonly IFileContentDisplayer _contentDisplayer;

    private readonly HashSet<string> _supportedModes;

    public FileShowParser(HashSet<string> supportedModes, IFileContentDisplayer contentDisplayer)
    {
        _supportedModes = supportedModes;
        _contentDisplayer = contentDisplayer;
    }

    protected override ICommand? TryParse(CommandTokens args)
    {
        if (tokens.Arguments.Count < 2) return null;
        if (tokens.Arguments[0] != "file" || tokens.Arguments[1] != "show") return null;

        if (tokens.Arguments.Count < 3)
            throw new ArgumentException("Path required");

        if (!tokens.Flags.ContainsKey("m"))
            throw new ArgumentException("Mode required");

        string path = tokens.Arguments[2];
        string mode = tokens.Flags["m"];

        if (!_supportedModes.Contains(mode))
            throw new ArgumentException("Unsupported mode provided");

        return new FileShowCommand(new Nodes.File(_path), _contentDisplayer);
    }
}
