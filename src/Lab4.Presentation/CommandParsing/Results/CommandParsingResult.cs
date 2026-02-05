using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Results;

public abstract record CommandParsingResult
{
    private CommandParsingResult() { }

    public sealed record CommandCreated(ICommand Command) : CommandParsingResult;

    public sealed record Failure(string Message) : CommandParsingResult;

    public sealed record Connect(string Address, string Mode) : CommandParsingResult;

    public sealed record Disconnect : CommandParsingResult;
}
