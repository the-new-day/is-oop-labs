using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Parsers;

public class ConnectParser : ParserHandler
{
    private readonly HashSet<string> _supportedModes;

    private readonly string _defaultMode;

    public ConnectParser(HashSet<string> supportedModes, string defaultMode)
    {
        _supportedModes = supportedModes;
        _defaultMode = defaultMode;
    }

    public override CommandParsingResult TryParse(CommandTokens tokens)
    {
        if (tokens.Arguments[0] != "connect")
            return CallNext(tokens);

        if (tokens.Arguments.Count < 2)
            return new CommandParsingResult.Failure("Address is required");

        string address = tokens.Arguments[1];
        string mode = _defaultMode;

        if (tokens.Arguments.Count > 2)
            mode = tokens.Arguments[2];

        if (!_supportedModes.Contains(mode))
            return new CommandParsingResult.Failure("Unsupported mode provided");

        return new CommandParsingResult.Connect(address, mode);
    }
}
