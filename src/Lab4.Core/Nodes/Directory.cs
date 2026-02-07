namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;

public class Directory : IFileSystemNode
{
    public UnixPath Path { get; }

    public string Name => Path.Name;

    public Directory(UnixPath path)
    {
        Path = path;
    }

    public Directory(string path)
    {
        Path = new UnixPath(path);
    }

    public UnixPath Combine(UnixPath relative)
    {
        return Path.Combine(relative);
    }

    public void Accept(IFileSystemNodeVisitor visitor)
    {
        visitor.Visit(this);
    }
}
