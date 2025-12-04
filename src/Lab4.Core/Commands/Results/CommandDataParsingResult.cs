namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Results;

public abstract record CommandDataParsingResult<TData>
{
    private CommandDataParsingResult() { }

    public sealed record Success(TData Data) : CommandDataParsingResult<TData>;

    public sealed record Failure : CommandDataParsingResult<TData>;
}
