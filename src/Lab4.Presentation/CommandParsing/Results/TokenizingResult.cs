namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Results;

public abstract record TokenizingResult
{
    private TokenizingResult() { }

    public sealed record Success(CommandTokens Tokens) : TokenizingResult;

    public sealed record Failure(string Message) : TokenizingResult;
}
