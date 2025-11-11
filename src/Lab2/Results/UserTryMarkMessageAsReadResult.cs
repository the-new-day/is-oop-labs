namespace Itmo.ObjectOrientedProgramming.Lab2.Results;

public abstract record UserTryMarkMessageAsReadResult
{
    private UserTryMarkMessageAsReadResult() { }

    public sealed record Success : UserTryMarkMessageAsReadResult;

    public sealed record MessageIsAlreadyRead : UserTryMarkMessageAsReadResult;

    public sealed record MessageHasNotBeenReceived : UserTryMarkMessageAsReadResult;
}
