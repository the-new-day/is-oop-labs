namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Results;

public abstract record CommandResult
{
    private CommandResult() { }

    public sealed record Success : CommandResult;

    public sealed record Failure : CommandResult;
}
