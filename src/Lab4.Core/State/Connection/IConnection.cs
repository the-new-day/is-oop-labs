using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using DirectoryNode = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.DirectoryNode;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.State.Connection;

public interface IConnection
{
    IFileSystem FileSystem { get; }

    DirectoryNode RootAddress { get; }
}
