using Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;
using System.Collections;
using DirectoryNode = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.DirectoryNode;
using FileNode = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.FileNode;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

public class FileSystemSliceIterator : IFileSystemNodeVisitor, IEnumerator<IFileSystemNode>
{
    private readonly Queue<(IFileSystemNode Node, int Depth)> _queue = new();

    private readonly IFileSystem _fileSystem;

    private readonly int _maxDepth;

    private IFileSystemNode? _current;

    private bool _initialized = false;

    public IFileSystemNode Current
        => _current ?? throw new InvalidOperationException("No current node");

    object IEnumerator.Current => Current;

    public FileSystemSliceIterator(IFileSystem fileSystem, int maxDepth)
    {
        if (maxDepth <= 0)
            throw new ArgumentException("Depth can't be <= 0", nameof(maxDepth));

        _fileSystem = fileSystem;
        _maxDepth = maxDepth;
    }

    public bool MoveNext()
    {
        if (!_initialized)
        {
            Initialize();
            _initialized = true;
        }

        if (_queue.Count == 0)
        {
            _current = null;
            return false;
        }

        (IFileSystemNode? node, int depth) = _queue.Dequeue();
        _current = node;

        if (depth < _maxDepth && node is DirectoryNode directory)
        {
            foreach (IFileSystemNode child in _fileSystem.GetChildren(directory))
            {
                _queue.Enqueue((child, depth + 1));
            }
        }

        return true;
    }

    public void Reset()
    {
        _initialized = false;
        _current = null;
        Initialize();
    }

    public void Dispose()
    {
        while (_queue.Count > 0)
        {
            _queue.Dequeue();
        }

        _current = null;
        _initialized = false;
    }

    public void Visit(DirectoryNode node)
    {
        _current = node;
    }

    public void Visit(FileNode node)
    {
        _current = node;
    }

    private void Initialize()
    {
        _queue.Clear();
        _queue.Enqueue((_fileSystem.Root, 0));
    }
}
