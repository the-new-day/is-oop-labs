using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;
using Directory = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.Directory;
using File = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Connection;

public class FileSystemPathProxy : IFileSystem, IChangeDirectorySubscriber
{
    private readonly IFileSystem _fileSystem;

    private Directory _currentDirectory;

    public FileSystemPathProxy(IFileSystem fileSystem, Directory currentDirectory)
    {
        _fileSystem = fileSystem;
        _currentDirectory = currentDirectory;
    }

    public FileSystemResult CopyFile(File file, Directory copyTo)
    {
        return _fileSystem.CopyFile(GetFile(file), GetDirectory(copyTo));
    }

    public FileSystemResult DeleteFile(File file)
    {
        return _fileSystem.DeleteFile(GetFile(file));
    }

    public DirectoryContentsResult GetContents(Directory directory)
    {
        return _fileSystem.GetContents(GetDirectory(directory));
    }

    public bool IsDirectory(UnixPath path)
    {
        return _fileSystem.IsDirectory(_currentDirectory.Path.Combine(path));
    }

    public bool IsFile(UnixPath path)
    {
        return _fileSystem.IsFile(_currentDirectory.Path.Combine(path));
    }

    public FileSystemResult MoveFile(File file, Directory moveTo)
    {
        return _fileSystem.MoveFile(GetFile(file), GetDirectory(moveTo));
    }

    public FileReadOpeningResult OpenRead(File file)
    {
        return _fileSystem.OpenRead(GetFile(file));
    }

    public FileSystemResult RenameFile(File file, string newName)
    {
        return _fileSystem.RenameFile(GetFile(file), newName);
    }

    public void OnChangeDirectory(Directory newDirectory)
    {
        _currentDirectory = newDirectory;
    }

    private File GetFile(File file)
    {
        UnixPath resolvedPath = _currentDirectory.Path.Combine(file.Path);
        return new File(resolvedPath);
    }

    private Directory GetDirectory(Directory directory)
    {
        return new Directory(_currentDirectory.Combine(directory.Path));
    }
}
