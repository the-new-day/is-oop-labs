namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public readonly record struct AttackPoints
{
    public int Value { get; }

    public AttackPoints(int value)
    {
        if (value < 0)
            throw new ArgumentException("AttackPoints can't be negative", nameof(value));

        Value = value;
    }

    public AttackPoints MultipliedBy(int multiplier)
    {
        if (multiplier < 0)
            throw new ArgumentException("multiplier can't be negative", nameof(multiplier));

        return new AttackPoints(Value * multiplier);
    }

    public bool IsZero => Value == 0;

    public static AttackPoints Max(AttackPoints left, AttackPoints right)
        => new AttackPoints(Math.Max(left.Value, right.Value));

    public static AttackPoints operator +(AttackPoints left, AttackPoints right)
        => new AttackPoints(left.Value + right.Value);

    public static AttackPoints operator -(AttackPoints left, AttackPoints right)
        => new AttackPoints(left.Value - right.Value);
}
