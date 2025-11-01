namespace Itmo.ObjectOrientedProgramming.Lab1.Physics;

public readonly record struct Time
{
    public double Value { get; }

    public Time(double value)
    {
        if (value < 0)
            throw new ArgumentException("Can't create Time: value can't be negative");

        Value = value;
    }

    public static Time operator +(Time left, Time right)
        => new Time(left.Value + right.Value);

    public static Time Create(Distance distance, Speed speed)
    {
        if (speed.IsZero)
            throw new ArgumentException("Can't calculate time: speed is zero", nameof(speed));

        return new Time(distance.Value / speed.Value);
    }

    public bool IsZero => Value == 0;
}
