namespace Itmo.ObjectOrientedProgramming.Lab1.Physics;

public readonly record struct Distance
{
    public double Value { get; }

    public Distance(double value)
    {
        if (value < 0)
            throw new ArgumentException("Distance can't be negative", nameof(value));

        Value = value;
    }

    public static Distance Create(Speed speed, Time time)
    {
        if (time.IsZero)
            throw new ArgumentException("Can't calculate distance: time is zero", nameof(time));

        return new Distance(Math.Abs(speed.Value) * time.Value);
    }

    public static Distance operator +(Distance left, Distance right)
        => new Distance(left.Value + right.Value);

    public static Distance operator -(Distance left, Distance right)
        => new Distance(left.Value - right.Value);

    public static bool operator >(Distance left, Distance right)
        => left.Value > right.Value;

    public static bool operator <(Distance left, Distance right)
        => left.Value < right.Value;

    public bool IsZero => Value == 0;
}
