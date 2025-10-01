using Lab1.Domain.Results;

namespace Lab1.Domain.Routes;

public interface IRouteSegment
{
    SegmentResult Pass(Train train);
}
