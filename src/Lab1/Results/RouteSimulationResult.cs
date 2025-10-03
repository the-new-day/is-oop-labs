using Lab1.Physics;

namespace Lab1.Results;

public abstract record RouteSimulationResult
{
    private RouteSimulationResult() { }

    public sealed record Success(Time Time) : RouteSimulationResult;

    public sealed record MaxEndSpeedExceeded : RouteSimulationResult;

    public sealed record SegmentPassFailed(SegmentPassingResult SegmentPassingResult) : RouteSimulationResult;
}
