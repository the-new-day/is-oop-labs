using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;
using Directory = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.Directory;
using File = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

public class LocalFileSystem : IFileSystem
{
    public FileSystemResult CopyFile(File file, Directory copyTo)
    {
        try
        {
            System.IO.File.Copy(file.Path.Value, copyTo.Path.Value + "/" + file.Name);
            return new FileSystemResult.Success();
        }
        catch (Exception e)
        {
            return new FileSystemResult.Failure(e.Message);
        }
    }

    public FileSystemResult DeleteFile(File file)
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

    public DirectoryContentsResult GetContents(Directory directory)
    {
        try
        {
            string[] entries = System.IO.Directory.GetFileSystemEntries(directory.Path.Value);
            List<IFileSystemNode> nodes = new();

            foreach (string fullPath in entries)
            {
                var path = new UnixPath(fullPath);

                if (System.IO.Directory.Exists(fullPath))
                {
                    nodes.Add(new Directory(path));
                }
                else
                {
                    nodes.Add(new File(path));
                }
            }

            return new DirectoryContentsResult.Success(nodes);
        }
        catch (Exception e)
        {
            return new DirectoryContentsResult.Failure(e.Message);
        }
    }

    public FileSystemResult MoveFile(File file, Directory moveTo)
    {
        try
        {
            System.IO.File.Move(file.Path.Value, moveTo.Path.Value + "/" + file.Name, true);
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

    public FileReadOpeningResult OpenRead(File file)
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

    public FileSystemResult RenameFile(File file, string newName)
    {
        try
        {
            System.IO.File.Move(file.Path.Value, file.ParentDir.Path.Combine(newName).Value);
            return new FileSystemResult.Success();
        }
        catch (Exception e)
        {
            return new FileSystemResult.Failure(e.Message);
        }
    }
}
