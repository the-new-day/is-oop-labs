using Lab1.Physics;
using Lab1.Results;

namespace Lab1.Routes;

public class RegularSegment : IRouteSegment
{
    public Distance Length { get; }

    public RegularSegment(Distance length)
    {
        Length = length;
    }

    public SegmentResult Pass(Train train)
    {
        TravelResult result = train.Travel(Length);
        return new SegmentResult(result.Success, result.Time);
    }
}
