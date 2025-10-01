using Lab1.Domain.Physics;
using Lab1.Domain.Results;

namespace Lab1.Domain.Routes;

public class Station : IRouteSegment
{
    public Speed MaxArrivalSpeed { get; }

    public Time UnloadLoadTime { get; }

    public Station(Speed maxArrivalSpeed, Time unloadLoadTime)
    {
        MaxArrivalSpeed = maxArrivalSpeed;
        UnloadLoadTime = unloadLoadTime;
    }

    public SegmentResult Pass(Train train)
    {
        if (train.Speed > MaxArrivalSpeed)
            return new SegmentResult(false, new Time(0));

        return new SegmentResult(true, UnloadLoadTime);
    }
}
