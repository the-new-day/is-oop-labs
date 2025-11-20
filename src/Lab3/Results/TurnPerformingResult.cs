namespace Itmo.ObjectOrientedProgramming.Lab3.Results;

public abstract record TurnPerformingResult
{
    private TurnPerformingResult() { }

    public sealed record PerformedNormally : TurnPerformingResult;

    public sealed record GameTied : TurnPerformingResult;

    public sealed record AttackerWins : TurnPerformingResult;

    public sealed record AttackerPasses : TurnPerformingResult;
}
