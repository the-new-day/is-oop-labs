namespace Lab1.Domain.Physics;

public readonly record struct Force
{
    public double Value { get; }

    public Force(double value)
    {
        Value = value;
    }

    public bool Exceeds(Force limit) => Math.Abs(Value) > Math.Abs(limit.Value);

    public bool IsPositive => Value > 0;

    public bool IsNegative => Value < 0;

    public bool IsZero => Value == 0;
}
