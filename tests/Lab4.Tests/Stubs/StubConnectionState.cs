using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Parsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Connection.State;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests.Stubs;

public class StubConnectionState : IConnectionState
{
    public ParserHandler GetParserHandler()
    {
        return new ConnectParser([], "Stub");
    }
}
