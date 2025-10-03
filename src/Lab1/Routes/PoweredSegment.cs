using Itmo.ObjectOrientedProgramming.Lab1.Physics;
using Itmo.ObjectOrientedProgramming.Lab1.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public class PoweredSegment : IRouteSegment
{
    public Distance Length { get; }

    public Force Force { get; }

    public PoweredSegment(Distance length, Force force)
    {
        Length = length;
        Force = force;
    }

    public SegmentPassingResult Pass(Train train)
    {
        TrainForceApplyingResult forceApplyingResult = train.TryApplyForce(Force);

        if (forceApplyingResult is TrainForceApplyingResult.AppliedForceExceedsLimit err)
            return new SegmentPassingResult.AppliedForceExceedsTrainLimit(err.Limit);

        TrainTravelResult result = train.Travel(Length);

        if (result is TrainTravelResult.Success success)
            return new SegmentPassingResult.Success(success.Time);

        return new SegmentPassingResult.TrainTravelFailed(result);
    }
}
