namespace Lab1.Domain.Physics;

public readonly record struct Speed
{
    public double Value { get; }

    public Speed(double value) => Value = value;

    public static Speed Create(Acceleration a, Time dt)
        => new Speed(a.Value * dt.Value);

    public static Speed operator +(Speed left, Speed right)
        => new Speed(left.Value + right.Value);

    public bool IsZero => Value == 0;

    public bool IsPositive => Value > 0;
}
