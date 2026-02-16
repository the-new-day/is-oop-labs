namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Results;

public abstract record CommandExecutionResult
{
    private CommandExecutionResult() { }

    public sealed record Success : CommandExecutionResult;

    public sealed record Failure(string Message) : CommandExecutionResult;
}
