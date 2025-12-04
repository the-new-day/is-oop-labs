using Path = Itmo.ObjectOrientedProgramming.Lab4.Core.Paths.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;

public interface IFileSystemNode
{
    string Name { get; }

    Path FullPath { get; }

    IFileSystemNode? FindParent();

    void Accept(IFileSystemNodeVisitor visitor);
}
