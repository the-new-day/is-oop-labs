using Lab1.Physics;

namespace Lab1.Results;

public abstract record TrainForceApplyingResult
{
    private TrainForceApplyingResult() { }

    public sealed record Success : TrainForceApplyingResult;

    public sealed record AppliedForceExceedsLimit(Force Limit) : TrainForceApplyingResult;
}
