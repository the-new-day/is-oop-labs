namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.AccountOperationHistory;

public readonly record struct OperationId(long Value)
{
    public static readonly OperationId Default = new(default);
}
