using Lab1.Physics;
using Lab1.Results;

namespace Lab1.Routes;

public class Route
{
    public IReadOnlyList<IRouteSegment> Segments { get; }

    public Speed MaxEndSpeed { get; }

    public Route(IEnumerable<IRouteSegment> segments, Speed maxEndSpeed)
    {
        Segments = segments.ToList();
        MaxEndSpeed = maxEndSpeed;
    }

    public RouteSimulationResult Simulate(Train train)
    {
        var totalTime = new Time(0);

        foreach (IRouteSegment segment in Segments)
        {
            SegmentPassingResult result = segment.Pass(train);

            if (result is not SegmentPassingResult.Success success)
                return new RouteSimulationResult.SegmentPassFailed(result);

            totalTime += success.Time;
        }

        if (train.Speed > MaxEndSpeed)
            return new RouteSimulationResult.MaxEndSpeedExceeded();

        return new RouteSimulationResult.Success(totalTime);
    }
}
