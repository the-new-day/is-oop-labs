using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.State.Connection.Results;
using IDirectory = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.IDirectory;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.State.Connection;

public interface IConnection
{
    IFileSystem FileSystem { get; }

    IDirectory RootDirectory { get; }

    IDirectory CurrentDirectory { get; }

    ConnectionChangeDirectoryResult TryChangeDirectory(IDirectory newDirectory);
}
