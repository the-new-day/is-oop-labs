namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Sessions;

public sealed class Session
{
    public SessionKey Key { get; }

    public SessionType Type { get; }

    public Session(SessionKey key, SessionType type)
    {
        Key = key;
        Type = type;
    }
}
