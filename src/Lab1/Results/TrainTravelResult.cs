using Lab1.Physics;

namespace Lab1.Results;

public abstract record TrainTravelResult
{
    private TrainTravelResult() { }

    public sealed record Success(Time Time) : TrainTravelResult;

    public sealed record AccelerationAndSpeedAreZero : TrainTravelResult;

    public sealed record SpeedBecameNonPositive : TrainTravelResult;
}
