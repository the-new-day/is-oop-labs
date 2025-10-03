using Lab1.Results;

namespace Lab1.Routes;

public interface IRouteSegment
{
    SegmentPassingResult Pass(Train train);
}
