using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Queries;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Persistence.Repositories;

internal sealed class InMemorySessionAccountRepository : ISessionAccountRepository
{
    private readonly Dictionary<SessionKey, AccountId> _values = [];

    public void Add(SessionKey sessionKey, AccountId accountId)
    {
        _values.Add(sessionKey, accountId);
    }

    public IEnumerable<AccountId> Query(SessionAccountQuery query)
    {
        return query.SessionKeys
            .Where(_values.ContainsKey)
            .Select(key => _values[key])
            .ToArray();
    }
}
