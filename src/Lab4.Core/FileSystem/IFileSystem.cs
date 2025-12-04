using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;
using DirectoryNode = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.DirectoryNode;
using FileNode = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.FileNode;
using Path = Itmo.ObjectOrientedProgramming.Lab4.Core.Paths.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

public interface IFileSystem
{
    DirectoryNode Root { get; }

    FileSystemResult SetRoot(DirectoryNode path);

    IFileSystemNode GetNode(Path path);

    IEnumerable<IFileSystemNode> GetChildren(DirectoryNode directory);

    FileReadOpeningResult OpenRead(FileNode file);

    FileSystemResult MoveFile(FileNode file, DirectoryNode moveTo);

    FileSystemResult CopyFile(FileNode file, DirectoryNode copyTo);

    FileSystemResult DeleteFile(FileNode file);

    FileSystemResult RenameFile(FileNode file, string newName);

    bool Exists(Path path);
}
