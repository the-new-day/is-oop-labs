namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public readonly record struct HealthPoints
{
    public int Value { get; }

    public HealthPoints(int value)
    {
        if (value < 0)
            throw new ArgumentException("HealthValue can't be negative", nameof(value));

        Value = value;
    }

    public bool IsZero => Value == 0;

    public static HealthPoints operator +(HealthPoints left, HealthPoints right)
        => new HealthPoints(left.Value + right.Value);

    public static HealthPoints operator -(HealthPoints left, HealthPoints right)
        => new HealthPoints(left.Value - right.Value);

    public static bool operator >(HealthPoints left, HealthPoints right)
        => left.Value > right.Value;

    public static bool operator <(HealthPoints left, HealthPoints right)
        => left.Value < right.Value;
}
