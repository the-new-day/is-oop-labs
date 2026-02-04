namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;

public interface IFileSystemNode
{
    UnixPath Path { get; }

    void Accept(IFileSystemNodeVisitor visitor);
}
