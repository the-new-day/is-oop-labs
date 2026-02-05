namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;

public class File : IFileSystemNode
{
    public UnixPath Path { get; }

    public string Name => Path.Value.Split('/').Last();

    public Directory ParentDir
    {
        get
        {
            int lastIndex = Path.Value.LastIndexOf('/');
            string parentPath = lastIndex >= 0 ? Path.Value.Substring(0, lastIndex) : Path.Value;
            return new Directory(new UnixPath(parentPath));
        }
    }

    public File(UnixPath path)
    {
        Path = path;
    }

    public File(string path)
    {
        Path = new UnixPath(path);
    }

    public void Accept(IFileSystemNodeVisitor visitor)
    {
        visitor.Visit(this);
    }
}
