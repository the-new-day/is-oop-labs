namespace Itmo.ObjectOrientedProgramming.Lab4.Core.State.Results;

public abstract record ConnectionChangeDirectoryResult
{
    private ConnectionChangeDirectoryResult() { }

    public sealed record Success : ConnectionChangeDirectoryResult;

    public sealed record DirectoryOutsideRoot : ConnectionChangeDirectoryResult;
}
