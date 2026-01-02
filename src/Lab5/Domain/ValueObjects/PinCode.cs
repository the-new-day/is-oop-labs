namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.ValueObjects;

public sealed record PinCode
{
    private readonly string _value;

    public PinCode(string value)
    {
        _value = value;
    }

    public bool Verify(PinCode code) => _value == code._value;
}
