using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Queries;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Persistence.Repositories;

internal sealed class InMemorySessionRepository : ISessionRepository
{
    private readonly Dictionary<SessionKey, Session> _values = [];

    public void Add(Session session)
    {
        _values.Add(session.Key, session);
    }

    public IEnumerable<Session> Query(SessionQuery query)
    {
        return _values.Values
            .Where(x => query.SessionKeys is [] || query.SessionKeys.Contains(x.Key));
    }
}
