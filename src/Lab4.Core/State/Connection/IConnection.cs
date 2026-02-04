using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.State.Connection.Results;
using Directory = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.Directory;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.State.Connection;

public interface IConnection
{
    IFileSystem FileSystem { get; }

    Directory RootDirectory { get; }

    Directory CurrentDirectory { get; }

    ConnectionChangeDirectoryResult TryChangeDirectory(Directory newDirectory);
}
