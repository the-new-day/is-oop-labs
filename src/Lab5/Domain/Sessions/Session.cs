namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Sessions;

public sealed class Session
{
    public SessionKey Key { get; }

    public ISessionType Type { get; }

    public Session(ISessionType type)
    {
        Key = new SessionKey(Guid.NewGuid());
        Type = type;
    }
}
