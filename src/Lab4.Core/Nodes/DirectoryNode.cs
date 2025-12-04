using Path = Itmo.ObjectOrientedProgramming.Lab4.Core.Paths.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;

public class DirectoryNode : IFileSystemNode
{
    public string Name { get; }

    public Path FullPath { get; }

    public DirectoryNode(Path path)
    {
        throw new NotImplementedException();
    }

    public IFileSystemNode? FindParent()
    {
        throw new NotImplementedException();
    }

    public void Accept(IFileSystemNodeVisitor visitor)
    {
        visitor.Visit(this);
    }
}
