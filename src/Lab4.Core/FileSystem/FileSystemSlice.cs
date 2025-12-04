using Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;
using System.Collections;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

public class FileSystemSlice : IEnumerable<IFileSystemNode>
{
    private readonly IFileSystem _fileSystem;

    private readonly int _maxDepth;

    public FileSystemSlice(IFileSystem fileSystem, int maxDepth)
    {
        _fileSystem = fileSystem;
    }

    public IEnumerator<IFileSystemNode> GetEnumerator()
    {
        return new FileSystemSliceIterator(_fileSystem, _maxDepth);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
