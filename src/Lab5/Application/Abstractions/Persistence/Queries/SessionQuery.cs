using Itmo.ObjectOrientedProgramming.Lab5.Domain.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Queries;

public sealed record SessionQuery(SessionKey[] SessionKeys)
{
    public sealed class Builder
    {
        private readonly List<SessionKey> _keys = [];

        public SessionQuery Build()
        {
            return new SessionQuery(_keys.ToArray());
        }

        public Builder WithKey(SessionKey key)
        {
            _keys.Add(key);
            return this;
        }
    }
}
