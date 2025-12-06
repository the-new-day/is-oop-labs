using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Infrastrucure.LocalFileSystem;

public class LocalFileSystem : IFileSystem
{
    public FileSystemResult CopyFile(IFile file, IDirectory copyTo)
    {
        throw new NotImplementedException();
    }

    public FileSystemResult DeleteFile(IFile file)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<IFileSystemNode> GetContents(IDirectory directory)
    {
        throw new NotImplementedException();
    }

    public FileSystemResult MoveFile(IFile file, IDirectory moveTo)
    {
        throw new NotImplementedException();
    }

    public FileReadOpeningResult OpenRead(IFile file)
    {
        throw new NotImplementedException();
    }

    public FileSystemResult RenameFile(IFile file, string newName)
    {
        throw new NotImplementedException();
    }

    public bool Exists(IPath path)
    {
        throw new NotImplementedException();
    }
}
