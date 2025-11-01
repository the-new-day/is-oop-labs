using Itmo.ObjectOrientedProgramming.Lab1.Physics;

namespace Itmo.ObjectOrientedProgramming.Lab1.Results;

public abstract record TrainForceApplyingResult
{
    private TrainForceApplyingResult() { }

    public sealed record Success : TrainForceApplyingResult;

    public sealed record AppliedForceExceedsLimit(Force Limit) : TrainForceApplyingResult;
}
