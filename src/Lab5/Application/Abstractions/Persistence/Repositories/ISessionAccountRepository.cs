using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Queries;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Repositories;

public interface ISessionAccountRepository
{
    void Add(SessionKey sessionKey, AccountId accountId);

    IEnumerable<AccountId> Query(SessionAccountQuery query);
}
