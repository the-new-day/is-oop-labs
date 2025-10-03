using Itmo.ObjectOrientedProgramming.Lab1.Physics;
using Itmo.ObjectOrientedProgramming.Lab1.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public class Station : IRouteSegment
{
    public Speed MaxArrivalSpeed { get; }

    public Time UnloadLoadTime { get; }

    public Station(Speed maxArrivalSpeed, Time unloadLoadTime)
    {
        MaxArrivalSpeed = maxArrivalSpeed;
        UnloadLoadTime = unloadLoadTime;
    }

    public SegmentPassingResult Pass(Train train)
    {
        if (train.Speed > MaxArrivalSpeed)
            return new SegmentPassingResult.TrainExceededMaxStationSpeed(MaxArrivalSpeed);

        return new SegmentPassingResult.Success(UnloadLoadTime);
    }
}
