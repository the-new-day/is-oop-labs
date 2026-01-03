using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistance.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Queries;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Persistance.Repositories;

public sealed class InMemoryAccountRepository : IAccountRepository
{
    private readonly Dictionary<AccountId, Account> _values = [];

    public Account Add(Account account)
    {
        account = new Account(
            new AccountId(_values.Count + 1),
            account.Balance,
            account.PinCode);

        _values.Add(account.Id, account);
        return account;
    }

    public IEnumerable<Account> Query(AccountQuery query)
    {
        return _values.Values
            .Where(x => query.AccountIds is [] || query.AccountIds.Contains(x.Id));
    }
}
