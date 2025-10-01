using Lab1.Domain.Physics;
using Lab1.Domain.Results;

namespace Lab1.Domain.Routes;

public class PoweredSegment : IRouteSegment
{
    public Distance Length { get; }

    public Force Force { get; }

    public PoweredSegment(Distance length, Force force)
    {
        Length = length;
        Force = force;
    }

    public SegmentResult Pass(Train train)
    {
        if (!train.TryApplyForce(Force))
            return new SegmentResult(false, new Time(0));

        TravelResult result = train.Travel(Length);
        return new SegmentResult(result.Success, result.Time);
    }
}
