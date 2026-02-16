namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;

public interface IFileSystemNodeVisitor
{
    void Visit(Directory node);

    void Visit(File node);
}
