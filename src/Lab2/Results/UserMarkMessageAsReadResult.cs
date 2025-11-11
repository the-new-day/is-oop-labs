namespace Itmo.ObjectOrientedProgramming.Lab2.Results;

public abstract record UserMarkMessageAsReadResult
{
    private UserMarkMessageAsReadResult() { }

    public sealed record Success : UserMarkMessageAsReadResult;

    public sealed record MessageIsAlreadyRead : UserMarkMessageAsReadResult;

    public sealed record MessageHasNotBeenRecieved : UserMarkMessageAsReadResult;
}
