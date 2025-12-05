namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;

public interface IFileSystemNodeVisitor
{
    void Visit(IDirectory node);

    void Visit(IFile node);
}
