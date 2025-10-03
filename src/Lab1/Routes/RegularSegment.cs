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

    public SegmentPassingResult Pass(Train train)
    {
        TrainTravelResult result = train.Travel(Length);

        if (result is TrainTravelResult.Success success)
            return new SegmentPassingResult.Success(success.Time);

        return new SegmentPassingResult.TrainTravelFailed(result);
    }
}
