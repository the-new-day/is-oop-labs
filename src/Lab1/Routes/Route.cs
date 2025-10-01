using Lab1.Physics;
using Lab1.Results;

namespace Lab1.Routes;

public class Route
{
    public static IRouteEndSpeedLimitBuilder Builder => new RouteBuilder();

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

    private class RouteBuilder : IRouteBuilder, IRouteEndSpeedLimitBuilder
    {
        private readonly List<IRouteSegment> _segments = new();
        private Speed _maxEndSpeed;

        public IRouteBuilder WithEndSpeedLimit(Speed limit)
        {
            _maxEndSpeed = limit;
            return this;
        }

        public IRouteBuilder AddRegular(Distance length)
        {
            _segments.Add(new RegularSegment(length));
            return this;
        }

        public IRouteBuilder AddPowered(Distance length, Force force)
        {
            _segments.Add(new PoweredSegment(length, force));
            return this;
        }

        public IRouteBuilder AddStation(Time unloadLoadTime, Speed maxArrivalSpeed)
        {
            _segments.Add(new Station(maxArrivalSpeed, unloadLoadTime));
            return this;
        }

        public Route Build()
        {
            return new Route(_segments, _maxEndSpeed);
        }
    }
}

public interface IRouteEndSpeedLimitBuilder
{
    IRouteBuilder WithEndSpeedLimit(Speed limit);
}

public interface IRouteBuilder
{
    IRouteBuilder AddRegular(Distance length);

    IRouteBuilder AddPowered(Distance length, Force force);

    IRouteBuilder AddStation(Time unloadLoadTime, Speed maxArrivalSpeed);

    Route Build();
}
