using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;
using Directory = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.Directory;
using File = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

public interface IFileSystem
{
    DirectoryContentsResult GetContents(Directory directory);

    FileReadOpeningResult OpenRead(File file);

    FileSystemResult MoveFile(File file, Directory moveTo);

    FileSystemResult CopyFile(File file, Directory copyTo);

    FileSystemResult DeleteFile(File file);

    FileSystemResult RenameFile(File file, string newName);

    bool IsFile(UnixPath path);

    bool IsDirectory(UnixPath path);
}
