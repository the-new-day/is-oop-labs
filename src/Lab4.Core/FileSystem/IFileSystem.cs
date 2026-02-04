using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

public interface IFileSystem
{
    DirectoryContentsResult GetContents(Nodes.Directory directory);

    FileReadOpeningResult OpenRead(Nodes.File file);

    FileSystemResult MoveFile(Nodes.File file, Nodes.Directory moveTo);

    FileSystemResult CopyFile(Nodes.File file, Nodes.Directory copyTo);

    FileSystemResult DeleteFile(Nodes.File file);

    FileSystemResult RenameFile(Nodes.File file, string newName);

    bool IsFile(UnixPath path);

    bool IsDirectory(UnixPath path);
}
