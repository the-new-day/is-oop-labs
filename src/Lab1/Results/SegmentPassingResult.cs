using Itmo.ObjectOrientedProgramming.Lab1.Physics;

namespace Itmo.ObjectOrientedProgramming.Lab1.Results;

public abstract record SegmentPassingResult
{
    private SegmentPassingResult() { }

    public sealed record Success(Time Time) : SegmentPassingResult;

    public sealed record AppliedForceExceedsTrainLimit(Force Limit) : SegmentPassingResult;

    public sealed record TrainTravelFailed(TrainTravelResult TrainTravelResult) : SegmentPassingResult;

    public sealed record TrainExceededMaxStationSpeed(Speed MaxSpeed) : SegmentPassingResult;
}
