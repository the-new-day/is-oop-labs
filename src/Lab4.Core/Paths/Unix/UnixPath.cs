namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Paths.Unix;

public class UnixPath : IPath
{
    public string Value { get; }

    public bool IsAbsolute => Value.StartsWith(RootPath);

    private const string RootPath = "/";

    private readonly UnixPathResolver _pathResolver = new();

    public UnixPath(string value)
    {
        Value = value;
    }

    public IPath? FindParent()
    {
        if (Value == RootPath)
            return null;

        return _pathResolver.Resolve(this, "..");
    }

    public IPath Combine(string relativePath)
    {
        return _pathResolver.Resolve(this, relativePath);
    }
}
