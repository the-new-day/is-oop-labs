namespace Lab1.Domain.Physics;

public readonly record struct Acceleration
{
    public double Value { get; }

    public Acceleration(double value)
    {
        Value = value;
    }

    public static Acceleration Create(Force force, Mass mass)
    {
        if (mass.IsZero)
            throw new ArgumentException("Can't calculate acceleration: mass is zero", nameof(mass));

        return new Acceleration(force.Value / mass.Value);
    }

    public bool IsZero => Value == 0;
}
