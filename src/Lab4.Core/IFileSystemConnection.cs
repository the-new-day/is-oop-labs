using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Directory = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.Directory;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core;

public interface IFileSystemConnection
{
    IFileSystem FileSystem { get; }

    Directory RootDirectory { get; }

    Directory CurrentDirectory { get; }

    void ChangeDirectory(Directory newDirectory);
}
