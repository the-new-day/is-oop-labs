using Itmo.ObjectOrientedProgramming.Lab4.Core.State;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Parsers;

public class ConnectParser : ParserHandler
{
    private readonly Dictionary<string, ConnectionMode> _supportedModes;

    public ConnectParser(Dictionary<string, ConnectionMode> supportedModes)
    {
        _supportedModes = supportedModes;
    }

    protected override CommandParsingResult TryParse(CommandTokens tokens)
    {
        if (tokens.Arguments[0] != "connect")
            return CallNext(tokens);

        if (tokens.Arguments.Count < 2)
            return new CommandParsingResult.Failure("Address is required");

        string address = tokens.Arguments[1];
        string mode = "local";

        if (tokens.Arguments.Count > 2)
            mode = tokens.Arguments[1];

        if (!_supportedModes.ContainsKey(mode))
            return new CommandParsingResult.Failure("Unsupported mode provided");

        return new CommandParsingResult.Connect(address, mode);
    }
}
