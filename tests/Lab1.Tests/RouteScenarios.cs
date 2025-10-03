using Lab1.Physics;
using Lab1.Results;
using Lab1.Routes;
using Xunit;

namespace Lab1.Tests;

public class RouteScenarios
{
    [Fact]
    public void RouteSimulate_WhenTrainAcceleratesWithinRouteLimit_ShouldReturnSuccess()
    {
        Train train = CreateDefaultTrain();

        List<IRouteSegment> segments = [
            new PoweredSegment(new Distance(100), new Force(2000)),
            new RegularSegment(new Distance(200))
        ];
        var route = new Route(segments, new Speed(50));

        RouteResult result = route.Simulate(train);

        Assert.True(result.Success);
    }

    [Fact]
    public void RouteSimulate_WhenTrainAcceleratesBeyondRouteLimit_ShouldReturnFailure()
    {
        Train train = CreateDefaultTrain();

        List<IRouteSegment> segments = [
            new PoweredSegment(new Distance(1000), new Force(2000)),
            new RegularSegment(new Distance(200))
        ];
        var route = new Route(segments, new Speed(50));

        RouteResult result = route.Simulate(train);

        Assert.False(result.Success);
    }

    [Fact]
    public void RouteSimulate_WhenTrainPassesStationWithinLimit_ShouldReturnSuccess()
    {
        Train train = CreateDefaultTrain();

        List<IRouteSegment> segments = [
            new PoweredSegment(new Distance(100), new Force(2000)),
            new RegularSegment(new Distance(200)),
            new Station(new Speed(40), new Time(100)),
            new RegularSegment(new Distance(50)),
        ];
        var route = new Route(segments, new Speed(50));

        RouteResult result = route.Simulate(train);

        Assert.True(result.Success);
    }

    [Fact]
    public void RouteSimulate_WhenTrainArrivesAtStationTooFast_ShouldReturnFailure()
    {
        Train train = CreateDefaultTrain();

        List<IRouteSegment> segments = [
            new PoweredSegment(new Distance(100), new Force(2000)),
            new Station(new Speed(15), new Time(100)),
            new RegularSegment(new Distance(500)),
        ];
        var route = new Route(segments, new Speed(50));

        RouteResult result = route.Simulate(train);

        Assert.False(result.Success);
    }

    [Fact]
    public void RouteSimulate_WhenTrainExceedsRouteEndLimit_ShouldReturnFailure()
    {
        Train train = CreateDefaultTrain();

        List<IRouteSegment> segments = [
            new PoweredSegment(new Distance(1000), new Force(2000)),
            new RegularSegment(new Distance(100)),
            new Station(new Speed(150000), new Time(100)),
            new RegularSegment(new Distance(100)),
        ];
        var route = new Route(segments, new Speed(50));

        RouteResult result = route.Simulate(train);

        Assert.False(result.Success);
    }

    [Fact]
    public void RouteSimulate_WhenTrainDeceleratesWithinAllLimits_ShouldReturnSuccess()
    {
        Train train = CreateDefaultTrain();

        List<IRouteSegment> segments = [
            new PoweredSegment(new Distance(1000), new Force(2000)),
            new RegularSegment(new Distance(100)),
            new PoweredSegment(new Distance(900), new Force(-2000)),
            new Station(new Speed(30), new Time(100)),
            new RegularSegment(new Distance(100)),
            new PoweredSegment(new Distance(1000), new Force(2000)),
            new RegularSegment(new Distance(100)),
            new PoweredSegment(new Distance(900), new Force(-2000)),
        ];
        var route = new Route(segments, new Speed(50));

        RouteResult result = route.Simulate(train);

        Assert.True(result.Success);
    }

    [Fact]
    public void RouteSimulate_WhenTrainHasNoInitialSpeedOrAcceleration_ShouldReturnFailure()
    {
        Train train = CreateDefaultTrain();

        List<IRouteSegment> segments = [
            new RegularSegment(new Distance(100)),
        ];
        var route = new Route(segments, new Speed(50));

        RouteResult result = route.Simulate(train);

        Assert.False(result.Success);
    }

    [Fact]
    public void RouteSimulate_WhenTrainStopsOrReversesOnPoweredSegments_ShouldReturnFailure()
    {
        Train train = CreateDefaultTrain();

        List<IRouteSegment> segments = [
            new PoweredSegment(new Distance(100), new Force(1000)),
            new PoweredSegment(new Distance(100), new Force(-2000)),
        ];
        var route = new Route(segments, new Speed(50));

        RouteResult result = route.Simulate(train);

        Assert.False(result.Success);
    }

    private Train CreateDefaultTrain()
        => new Train(new Mass(1000), new Force(5000), new Time(0.1));
}
