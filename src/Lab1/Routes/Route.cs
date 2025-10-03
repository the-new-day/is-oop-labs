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

    public RouteResult Simulate(Train train)
    {
        var totalTime = new Time(0);

        foreach (IRouteSegment segment in Segments)
        {
            SegmentResult result = segment.Pass(train);
            totalTime += result.Time;

            if (!result.Success)
                return new RouteResult(false, totalTime);
        }

        if (train.Speed > MaxEndSpeed)
            return new RouteResult(false, totalTime);

        return new RouteResult(true, totalTime);
    }
}
