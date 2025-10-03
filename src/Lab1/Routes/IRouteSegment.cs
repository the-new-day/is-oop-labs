using Itmo.ObjectOrientedProgramming.Lab1.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public interface IRouteSegment
{
    SegmentPassingResult Pass(Train train);
}
