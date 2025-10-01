using Lab1.Results;

namespace Lab1.Routes;

public interface IRouteSegment
{
    SegmentResult Pass(Train train);
}
