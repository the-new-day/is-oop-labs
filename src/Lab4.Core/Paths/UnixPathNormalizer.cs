namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

internal class UnixPathNormalizer
{
    public Path Normalize(Path rootPath, string path)
    {
        string[] rawSegments = path.Split('/');

        if (rawSegments.Length == 0)
            return rootPath;

        Stack<string> segments = new();

        if (rawSegments[0].Length != 0)
            segments = new(SplitPath(rootPath));

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

        return new Path(string.Join('/', segments.ToArray()));
    }

    private string[] SplitPath(Path path)
    {
        return path.NormalizedFullPath.Split('/');
    }
}
