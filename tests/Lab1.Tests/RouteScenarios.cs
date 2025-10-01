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
        Route route = Route.Builder
            .WithEndSpeedLimit(new Speed(50))
            .AddPowered(new Distance(100), new Force(2000))
            .AddRegular(new Distance(200))
            .Build();

        RouteResult result = route.Simulate(train);

        Assert.True(result.Success);
    }

    [Fact]
    public void RouteSimulate_WhenTrainAcceleratesBeyondRouteLimit_ShouldReturnFailure()
    {
        Train train = CreateDefaultTrain();
        Route route = Route.Builder
            .WithEndSpeedLimit(new Speed(50))
            .AddPowered(new Distance(1000), new Force(2000))
            .AddRegular(new Distance(200))
            .Build();

        RouteResult result = route.Simulate(train);

        Assert.False(result.Success);
    }

    [Fact]
    public void RouteSimulate_WhenTrainPassesStationWithinLimit_ShouldReturnSuccess()
    {
        Train train = CreateDefaultTrain();
        Route route = Route.Builder
            .WithEndSpeedLimit(new Speed(50))
            .AddPowered(new Distance(100), new Force(2000))
            .AddRegular(new Distance(200))
            .AddStation(new Time(100), new Speed(40))
            .AddRegular(new Distance(50))
            .Build();

        RouteResult result = route.Simulate(train);

        Assert.True(result.Success);
    }

    [Fact]
    public void RouteSimulate_WhenTrainArrivesAtStationTooFast_ShouldReturnFailure()
    {
        Train train = CreateDefaultTrain();
        Route route = Route.Builder
            .WithEndSpeedLimit(new Speed(50))
            .AddPowered(new Distance(100), new Force(2000))
            .AddStation(new Time(100), new Speed(15))
            .AddRegular(new Distance(500))
            .Build();

        RouteResult result = route.Simulate(train);

        Assert.False(result.Success);
    }

    [Fact]
    public void RouteSimulate_WhenTrainExceedsRouteEndLimit_ShouldReturnFailure()
    {
        Train train = CreateDefaultTrain();
        Route route = Route.Builder
            .WithEndSpeedLimit(new Speed(50))
            .AddPowered(new Distance(1000), new Force(2000))
            .AddRegular(new Distance(100))
            .AddStation(new Time(100), new Speed(150000))
            .AddRegular(new Distance(100))
            .Build();

        RouteResult result = route.Simulate(train);

        Assert.False(result.Success);
    }

    [Fact]
    public void RouteSimulate_WhenTrainDeceleratesWithinAllLimits_ShouldReturnSuccess()
    {
        Train train = CreateDefaultTrain();
        Route route = Route.Builder
            .WithEndSpeedLimit(new Speed(50))
            .AddPowered(new Distance(1000), new Force(2000))
            .AddRegular(new Distance(100))
            .AddPowered(new Distance(900), new Force(-2000))
            .AddStation(new Time(100), new Speed(30))
            .AddRegular(new Distance(100))
            .AddPowered(new Distance(1000), new Force(2000))
            .AddRegular(new Distance(100))
            .AddPowered(new Distance(900), new Force(-2000))
            .Build();

        RouteResult result = route.Simulate(train);

        Assert.True(result.Success);
    }

    [Fact]
    public void RouteSimulate_WhenTrainHasNoInitialSpeedOrAcceleration_ShouldReturnFailure()
    {
        Train train = CreateDefaultTrain();
        Route route = Route.Builder
            .WithEndSpeedLimit(new Speed(50))
            .AddRegular(new Distance(100))
            .Build();

        RouteResult result = route.Simulate(train);

        Assert.False(result.Success);
    }

    [Fact]
    public void RouteSimulate_WhenTrainStopsOrReversesOnPoweredSegments_ShouldReturnFailure()
    {
        Train train = CreateDefaultTrain();
        Route route = Route.Builder
            .WithEndSpeedLimit(new Speed(50))
            .AddPowered(new Distance(100), new Force(1000))
            .AddPowered(new Distance(100), new Force(-2000))
            .Build();

        RouteResult result = route.Simulate(train);

        Assert.False(result.Success);
    }

    private Train CreateDefaultTrain()
        => new Train(new Mass(1000), new Force(5000), new Time(0.1));
}
