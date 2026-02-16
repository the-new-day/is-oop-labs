namespace Itmo.ObjectOrientedProgramming.Lab3.Results;

public abstract record BattleResult
{
    private BattleResult() { }

    public sealed record Tied : BattleResult;

    public sealed record FirstWins : BattleResult;

    public sealed record SecondWins : BattleResult;
}
