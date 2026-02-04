using Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Results;

public abstract record DirectoryContentsResult
{
    private DirectoryContentsResult() { }

    public sealed record Success(IEnumerable<IFileSystemNode> Nodes) : DirectoryContentsResult;

    public sealed record Failure(Exception? Exception) : DirectoryContentsResult;
}
