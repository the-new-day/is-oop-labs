using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Connection.State;

public interface IConnectionState
{
    ParserHandler GetParserHandler();
}
