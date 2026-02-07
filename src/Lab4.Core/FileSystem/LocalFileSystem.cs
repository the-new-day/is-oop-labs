using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

public class LocalFileSystem : IFileSystem
{
    public FileSystemResult CopyFile(Nodes.File file, Nodes.Directory copyTo)
    {
        try
        {
            System.IO.File.Copy(file.Path.Value, copyTo.Path + "/" + file.Name);
            return new FileSystemResult.Success();
        }
        catch (Exception e)
        {
            return new FileSystemResult.Failure(e.Message);
        }
    }

    public FileSystemResult DeleteFile(Nodes.File file)
    {
        try
        {
            System.IO.File.Delete(file.Path.Value);
            return new FileSystemResult.Success();
        }
        catch (Exception e)
        {
            return new FileSystemResult.Failure(e.Message);
        }
    }

    public DirectoryContentsResult GetContents(Nodes.Directory directory)
    {
        try
        {
            string[] names = System.IO.Directory.GetFiles(directory.Path.Value);
            List<IFileSystemNode> nodes = new();

            foreach (string name in names)
            {
                UnixPath path = directory.Combine(new UnixPath(name));

                if (IsDirectory(path))
                {
                    nodes.Add(new Nodes.Directory(path));
                }
                else
                {
                    nodes.Add(new Nodes.File(path));
                }
            }

            return new DirectoryContentsResult.Success(nodes);
        }
        catch (Exception e)
        {
            return new DirectoryContentsResult.Failure(e.Message);
        }
    }

    public FileSystemResult MoveFile(Nodes.File file, Nodes.Directory moveTo)
    {
        try
        {
            System.IO.File.Move(file.Path.Value, moveTo.Path + "/" + file.Name);
            return new FileSystemResult.Success();
        }
        catch (Exception e)
        {
            return new FileSystemResult.Failure(e.Message);
        }
    }

    public bool IsDirectory(UnixPath path)
    {
        return System.IO.Directory.Exists(path.Value);
    }

    public bool IsFile(UnixPath path)
    {
        return System.IO.File.Exists(path.Value);
    }

    public FileReadOpeningResult OpenRead(Nodes.File file)
    {
        try
        {
            return new FileReadOpeningResult.Success(System.IO.File.Open(file.Path.Value, FileMode.Open));
        }
        catch (Exception e)
        {
            return new FileReadOpeningResult.Failure(e.Message);
        }
    }

    public FileSystemResult RenameFile(Nodes.File file, string newName)
    {
        try
        {
            System.IO.File.Move(file.Path.Value, file.ParentDir.Path.Value + "/" + file.Name);
            return new FileSystemResult.Success();
        }
        catch (Exception e)
        {
            return new FileSystemResult.Failure(e.Message);
        }
    }
}
