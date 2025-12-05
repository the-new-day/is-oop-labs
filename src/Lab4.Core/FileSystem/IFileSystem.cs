using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

public interface IFileSystem
{
    IEnumerable<IFileSystemNode> GetContents(IDirectory directory);

    FileReadOpeningResult OpenRead(IFile file);

    FileSystemResult MoveFile(IFile file, IDirectory moveTo);

    FileSystemResult CopyFile(IFile file, IDirectory copyTo);

    FileSystemResult DeleteFile(IFile file);

    FileSystemResult RenameFile(IFile file, string newName);

    bool Exists(IPath path);
}
