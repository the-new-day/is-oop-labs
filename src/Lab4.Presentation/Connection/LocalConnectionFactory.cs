using Itmo.ObjectOrientedProgramming.Lab4.Core;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Connection.State;
using Directory = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.Directory;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Connection;

public class LocalConnectionFactory : IConnectionFactory
{
    private readonly IConnectionState _initialState;

    public LocalConnectionFactory(IConnectionState initialState)
    {
        _initialState = initialState;
    }

    public IFileSystemConnection Create(Directory rootDirectory)
    {
        IFileSystem fileSystem = new LocalFileSystem();
        var proxy = new FileSystemPathProxy(fileSystem, rootDirectory);

        var connection = new FileSystemConnection(
            proxy,
            rootDirectory,
            _initialState);

        connection.Subscribe(proxy);
        return connection;
    }
}
