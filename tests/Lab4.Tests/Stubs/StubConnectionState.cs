using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Parsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.State;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests.Mocks;

public class StubConnectionState : IConnectionState
{
    public ParserHandler GetParserHandler()
    {
        return new ConnectParser([], "Stub");
    }
}
