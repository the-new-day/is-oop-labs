namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Paths.Unix;

public class UnixPathFactory : IPathFactory
{
    public IPath Create(string path)
    {
        var absoluteRootPath = new UnixPath("/");
        return absoluteRootPath.Combine(path);
    }
}
