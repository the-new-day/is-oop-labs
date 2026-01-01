namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.ValueObjects;

public sealed record PinCode
{
    private readonly string _value;

    public PinCode(string value)
    {
        if (value.Length != 4)
            throw new ArgumentException("PinCode must contain exactly 4 characters");

        if (value.All(char.IsDigit) is false)
            throw new ArgumentException("PinCode must contain only numeric characters");

        _value = value;
    }

    public bool Verify(PinCode code) => _value == code._value;
}
