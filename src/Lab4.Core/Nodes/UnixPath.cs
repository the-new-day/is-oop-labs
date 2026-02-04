namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;

public class UnixPath
{
    public string Value { get; }

    public bool IsAbsolute => Value.StartsWith(RootPath);

    private const string RootPath = "/";

    public UnixPath(string value)
    {
        Value = Resolve(RootPath, value);
    }

    private static string Resolve(string rootPath, string relativePath)
    {
        string[] rawSegments = relativePath.Split('/');

        if (rawSegments.Length == 0)
            return rootPath;

        Stack<string> segments = new();

        if (rawSegments[0].Length != 0)
            segments = new(rootPath.Split('/'));

        foreach (string segment in rawSegments)
        {
            if (segment.Length == 0 || segment == ".")
            {
                continue;
            }

            if (segment == "..")
            {
                segments.Pop();
                continue;
            }

            segments.Push(segment);
        }

        return string.Join('/', segments.ToArray());
    }
}
