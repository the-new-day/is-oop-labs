namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Results;

public abstract record FileSystemResult
{
    protected FileSystemResult() { }

    public sealed record Success : FileSystemResult;

    public sealed record Failure(Exception? Exception) : FileSystemResult;
}