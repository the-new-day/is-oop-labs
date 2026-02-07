using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Connection;

public class FileSystemPathProxy : IFileSystem, IChangeDirectorySubscriber
{
    private readonly IFileSystem _fileSystem;

    private Core.Nodes.Directory _currentDirectory;

    public FileSystemPathProxy(IFileSystem fileSystem, Core.Nodes.Directory currentDirectory)
    {
        _fileSystem = fileSystem;
        _currentDirectory = currentDirectory;
    }

    public FileSystemResult CopyFile(Core.Nodes.File file, Core.Nodes.Directory copyTo)
    {
        return _fileSystem.CopyFile(GetFile(file), GetDirectory(copyTo));
    }

    public FileSystemResult DeleteFile(Core.Nodes.File file)
    {
        Console.WriteLine(GetFile(file).Path.Value);
        return _fileSystem.DeleteFile(GetFile(file));
    }

    public DirectoryContentsResult GetContents(Core.Nodes.Directory directory)
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

    public FileSystemResult MoveFile(Core.Nodes.File file, Core.Nodes.Directory moveTo)
    {
        return _fileSystem.MoveFile(GetFile(file), GetDirectory(moveTo));
    }

    public FileReadOpeningResult OpenRead(Core.Nodes.File file)
    {
        return _fileSystem.OpenRead(GetFile(file));
    }

    public FileSystemResult RenameFile(Core.Nodes.File file, string newName)
    {
        return _fileSystem.RenameFile(GetFile(file), newName);
    }

    public void OnChangeDirectory(Core.Nodes.Directory newDirectory)
    {
        _currentDirectory = newDirectory;
    }

    private Core.Nodes.File GetFile(Core.Nodes.File file)
    {
        UnixPath resolvedPath = _currentDirectory.Path.Combine(file.Path);
        return new Core.Nodes.File(resolvedPath);
    }

    private Core.Nodes.Directory GetDirectory(Core.Nodes.Directory directory)
    {
        return new Core.Nodes.Directory(_currentDirectory.Combine(directory.Path));
    }
}
