namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;

public class Directory : IFileSystemNode
{
    public UnixPath Path { get; }

    public Directory(UnixPath path)
    {
        Path = path;
    }

    public UnixPath Combine(UnixPath relative)
    {
        return new UnixPath(Path.Value + "/" + relative.Value);
    }

    public void Accept(IFileSystemNodeVisitor visitor)
    {
        visitor.Visit(this);
    }
}
