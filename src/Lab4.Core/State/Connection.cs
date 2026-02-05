using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.State.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.State;

public class Connection : IConnection
{
    public IFileSystem FileSystem { get; }

    public Nodes.Directory RootDirectory { get; }

    public Nodes.Directory CurrentDirectory { get; private set; }

    private readonly IDirectoryScopeEvaluator _scopeEvaluator;

    public Connection(
        IFileSystem fileSystem,
        Nodes.Directory rootDirectory,
        IDirectoryScopeEvaluator scopeEvaluator)
    {
        FileSystem = fileSystem;
        RootDirectory = rootDirectory;
        CurrentDirectory = rootDirectory;
        _scopeEvaluator = scopeEvaluator;
    }

    public ConnectionChangeDirectoryResult TryChangeDirectory(Nodes.Directory newDirectory)
    {
        if (_scopeEvaluator.IsNodeWithinRootScore(RootDirectory, newDirectory))
        {
            CurrentDirectory = newDirectory;
            return new ConnectionChangeDirectoryResult.Success();
        }

        return new ConnectionChangeDirectoryResult.DirectoryOutsideRoot();
    }
}
