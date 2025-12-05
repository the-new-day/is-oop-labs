using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;

public interface IFileSystemNode
{
    IPath Path { get; }

    void Accept(IFileSystemNodeVisitor visitor);
}
