namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Results;

public abstract record FileReadOpeningResult
{
    private FileReadOpeningResult() { }

    public sealed record Success(FileStream FileStream) : FileReadOpeningResult;

    public sealed record Failure(Exception? Exception) : FileReadOpeningResult;
}
