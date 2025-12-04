namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

public class PathFactory
{
    private readonly UnixPathNormalizer _pathNormalizer = new();

    public Path Create(string absolutePath)
    {
        var defaultRootPath = new Path("/");
        return _pathNormalizer.Normalize(defaultRootPath, absolutePath);
    }

    public Path Create(Path absoluteRootPath, string relativePath)
    {
        return _pathNormalizer.Normalize(absoluteRootPath, relativePath);
    }
}
