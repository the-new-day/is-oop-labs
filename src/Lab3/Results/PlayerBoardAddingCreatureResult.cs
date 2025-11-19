namespace Itmo.ObjectOrientedProgramming.Lab3.Results;

public abstract record PlayerBoardAddingCreatureResult
{
    private PlayerBoardAddingCreatureResult() { }

    public sealed record Success(int Position) : PlayerBoardAddingCreatureResult;

    public sealed record CreatureLimitExceeded(int Limit) : PlayerBoardAddingCreatureResult;
}