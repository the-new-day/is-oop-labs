using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Connection.State;

public class DisconnectedState : IConnectionState
{
    private readonly HashSet<string> _supportedConnectionModes;

    private readonly string _defaultConnectionMode;

    public DisconnectedState(
        HashSet<string> supportedConnectionModes,
        string defaultConnectionMode)
    {
        _supportedConnectionModes = supportedConnectionModes;
        _defaultConnectionMode = defaultConnectionMode;
    }

    public ParserHandler GetParserHandler()
    {
        return new CommandNodeParser(
            "connect",
            new ConnectParser(_supportedConnectionModes, _defaultConnectionMode));
    }
}
