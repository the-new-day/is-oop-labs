using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.State.Connection.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.State.Connection;

public class ConnectionBridge : IConnection
{
    public IFileSystem FileSystem { get; }

    public IDirectory RootDirectory { get; }

    public IDirectory CurrentDirectory { get; private set; }

    private readonly IDirectoryScopeEvaluator _scoreEvaluator;

    public ConnectionBridge(
        IFileSystem fileSystem,
        IDirectory rootDirectory,
        IDirectoryScopeEvaluator scopeEvaluator)
    {
        FileSystem = fileSystem;
        RootDirectory = rootDirectory;
        CurrentDirectory = rootDirectory;
        _scoreEvaluator = scopeEvaluator;
    }

    public ConnectionChangeDirectoryResult TryChangeDirectory(IDirectory newDirectory)
    {
        if (_scoreEvaluator.IsDirectoryWithinRootScore(RootDirectory, newDirectory))
        {
            CurrentDirectory = newDirectory;
            return new ConnectionChangeDirectoryResult.Success();
        }

        return new ConnectionChangeDirectoryResult.DirectoryOutsideRoot();
    }
}
