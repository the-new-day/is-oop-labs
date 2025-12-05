namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

public interface IPath
{
    string Value { get; }

    bool IsAbsolute { get; }

    IPath? FindParent();

    IPath Combine(string relativePath);
}
