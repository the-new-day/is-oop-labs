namespace Itmo.ObjectOrientedProgramming.Lab4.Core.State.Connection.Results;

public abstract record ConnectionChangeDirectoryResult
{
    private ConnectionChangeDirectoryResult() { }

    public sealed record Success : ConnectionChangeDirectoryResult;

    public sealed record DirectoryOutsideRoot : ConnectionChangeDirectoryResult;
}
