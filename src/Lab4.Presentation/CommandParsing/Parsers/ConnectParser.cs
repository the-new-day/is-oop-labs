using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Parsers;

public class ConnectParser : CommandLeafParser
{
    private readonly HashSet<string> _supportedModes;

    private readonly string _defaultMode;

    public ConnectParser(HashSet<string> supportedModes, string defaultMode)
    {
        _supportedModes = supportedModes;
        _defaultMode = defaultMode;
    }

    protected override CommandParsingResult BuildCommand(CommandTokens tokens)
    {
        if (tokens.Arguments.Count < 1)
            return new CommandParsingResult.Failure("Address is required");

        string address = tokens.Arguments.ElementAt(0);
        string mode = _defaultMode;

        if (tokens.Arguments.Count > 1)
            mode = tokens.Arguments.ElementAt(1);

        if (!_supportedModes.Contains(mode))
            return new CommandParsingResult.Failure("Unsupported mode provided");

        return new CommandParsingResult.Connect(address, mode);
    }
}
