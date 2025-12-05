namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Paths.Unix;

public class UnixPathResolver
{
    public UnixPath Resolve(UnixPath rootPath, string relativePath)
    {
        string[] rawSegments = relativePath.Split('/');

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
                if (segments.Count == 0)
                {
                    break; // TODO: failure
                }

                segments.Pop();
                continue;
            }

            segments.Push(segment);
        }

        return new UnixPath(string.Join('/', segments.ToArray()));
    }

    private string[] SplitPath(UnixPath path)
    {
        return path.Value.Split('/');
    }
}
