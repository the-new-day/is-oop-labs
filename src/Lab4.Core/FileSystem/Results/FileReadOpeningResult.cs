using Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Results;

public abstract record FileReadOpeningResult
{
    private FileReadOpeningResult() { }

    public sealed record Success(Stream FileStream, IFile File) : FileReadOpeningResult;

    public sealed record Failure : FileReadOpeningResult;
}
