namespace Lab1.Physics;

public readonly record struct Mass
{
    public double Value { get; }

    public Mass(double value)
    {
        if (value <= 0)
            throw new ArgumentException("Mass must be positive", nameof(value));

        Value = value;
    }

    public bool IsZero => Value == 0;
}
