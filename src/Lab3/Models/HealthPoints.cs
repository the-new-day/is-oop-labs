namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public readonly record struct HealthPoints
{
    public int Value { get; }

    public HealthPoints(int value)
    {
        if (value < 0)
            throw new ArgumentException("HealthPoints can't be negative", nameof(value));

        Value = value;
    }

    public HealthPoints MultipliedBy(int multiplier)
    {
        return new HealthPoints(Value * multiplier);
    }

    public bool IsZero => Value == 0;

    public static HealthPoints Max(HealthPoints left, HealthPoints right)
        => new HealthPoints(Math.Max(left.Value, right.Value));

    public static HealthPoints operator +(HealthPoints left, HealthPoints right)
        => new HealthPoints(left.Value + right.Value);

    public static HealthPoints operator -(HealthPoints left, HealthPoints right)
        => new HealthPoints(left.Value - right.Value);

    public static bool operator >(HealthPoints left, HealthPoints right)
        => left.Value > right.Value;

    public static bool operator <(HealthPoints left, HealthPoints right)
        => left.Value < right.Value;
}
