namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;

public class UnixPath
{
    public string Value { get; }

    public bool IsAbsolute => Value.StartsWith('/');

    public string Name => Value.Split('/', StringSplitOptions.RemoveEmptyEntries).LastOrDefault() ?? (IsAbsolute ? "/" : ".");

    public UnixPath(string value)
    {
        Value = Normalize(value);
    }

    public UnixPath Combine(UnixPath other)
    {
        if (other.IsAbsolute) return other;

        string combined = Value + "/" + other.Value;
        return new UnixPath(combined);
    }

    private static string Normalize(string path)
    {
        if (string.IsNullOrWhiteSpace(path)) return ".";

        bool startsWithSlash = path.StartsWith('/');
        string[] rawSegments = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
        List<string> resultSegments = new();

        foreach (string segment in rawSegments)
        {
            if (segment == ".") continue;

            if (segment == "..")
            {
                if (resultSegments.Count > 0 && resultSegments[^1] != "..")
                {
                    resultSegments.RemoveAt(resultSegments.Count - 1);
                }
                else if (!startsWithSlash)
                {
                    resultSegments.Add("..");
                }

                continue;
            }

            resultSegments.Add(segment);
        }

        string joined = string.Join('/', resultSegments);

        if (startsWithSlash)
        {
            return "/" + joined;
        }

        return resultSegments.Count == 0 ? "." : joined;
    }
}
