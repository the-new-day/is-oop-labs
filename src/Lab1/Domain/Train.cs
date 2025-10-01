using Lab1.Domain.Physics;
using Lab1.Domain.Results;

namespace Lab1.Domain;

public class Train
{
    public Mass Mass { get; }

    public Speed Speed { get; private set; }

    public Acceleration Acceleration { get; private set; }

    public Force MaxForce { get; }

    public Time Precision { get; }

    public Train(Mass mass, Force maxForce, Time precision)
    {
        if (precision.IsZero)
            throw new ArgumentException("Can't create Train: precision is zero", nameof(precision));
        else if (maxForce.IsNegative)
            throw new ArgumentException("Can't create Train: maxForce is negative", nameof(maxForce));

        Mass = mass;
        MaxForce = maxForce;
        Speed = new Speed(0);
        Acceleration = new Acceleration(0);
        Precision = precision;
    }

    public bool TryApplyForce(Force force)
    {
        if (force.Exceeds(MaxForce))
            return false;

        Acceleration = Acceleration.Create(force, Mass);
        return true;
    }

    public TravelResult Travel(Distance distance)
    {
        Distance remainingDistance = distance;
        var elapsedTime = new Time(0);
        Speed currentSpeed = Speed;

        if (Acceleration.IsZero || currentSpeed.IsZero)
            return new TravelResult(false, elapsedTime);

        while (!remainingDistance.IsZero)
            {
                currentSpeed += Speed.Create(Acceleration, Precision);
                if (!currentSpeed.IsPositive)
                    return new TravelResult(false, elapsedTime);

                var traveledDistance = Distance.Create(currentSpeed, Precision);

                if (traveledDistance > remainingDistance)
                {
                    var lastDt = Time.Create(remainingDistance, currentSpeed);
                    elapsedTime += lastDt;
                    remainingDistance = new Distance(0);
                    break;
                }

                remainingDistance -= traveledDistance;
                elapsedTime += Precision;
            }

        Speed = currentSpeed;
        return new TravelResult(true, elapsedTime);
    }
}
