namespace Itmo.ObjectOrientedProgramming.Lab1.Physics;

public readonly record struct Acceleration
{
    public double Value { get; }

    public Acceleration(double value)
    {
        Value = value;
    }

    public static Acceleration Create(Force force, Mass mass)
    {
        return new Acceleration(force.Value / mass.Value);
    }

    public bool IsZero => Value == 0;
}
