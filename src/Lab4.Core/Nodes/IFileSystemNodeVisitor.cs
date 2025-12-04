namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;

public interface IFileSystemNodeVisitor
{
    void Visit(DirectoryNode node);

    void Visit(FileNode node);
}
