using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;
using Directory = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.Directory;
using File = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests.Mocks;

public class StubFileSystem : IFileSystem
{
    public FileSystemResult CopyFile(File file, Directory copyTo) => new FileSystemResult.Success();

    public FileSystemResult DeleteFile(File file) => new FileSystemResult.Success();

    public DirectoryContentsResult GetContents(Directory directory)
        => new DirectoryContentsResult.Success(new List<IFileSystemNode>());

    public bool IsDirectory(UnixPath path) => false;

    public bool IsFile(UnixPath path) => false;

    public FileSystemResult MoveFile(File file, Directory moveTo) => new FileSystemResult.Success();

    public FileReadOpeningResult OpenRead(File file) => new FileReadOpeningResult.Failure("Stub");

    public FileSystemResult RenameFile(File file, string newName) => new FileSystemResult.Success();
}