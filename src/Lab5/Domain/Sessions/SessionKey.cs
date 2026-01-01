namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Sessions;

public readonly record struct SessionKey(Guid Value)
{
     public static readonly SessionKey Default = new(default);
}
