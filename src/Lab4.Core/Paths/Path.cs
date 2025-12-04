namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

public class Path
{
    public string NormalizedFullPath { get; }

    public Path(string normalizedFullPath)
    {
        NormalizedFullPath = normalizedFullPath; // TODO: validate
    }

    public Path? FindParent()
    {
        return null;
    }

    public bool IsSubpathOf(Path other)
    {
        return false;
    }
}
