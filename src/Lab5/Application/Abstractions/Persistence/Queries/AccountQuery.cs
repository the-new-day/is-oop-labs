using Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Queries;

public sealed record AccountQuery(AccountId[] AccountIds)
{
    public sealed class Builder
    {
        private readonly List<AccountId> _accountIds = [];

        public AccountQuery Build()
        {
            return new AccountQuery(_accountIds.ToArray());
        }

        public Builder WithId(AccountId id)
        {
            _accountIds.Add(id);
            return this;
        }
    }
}
