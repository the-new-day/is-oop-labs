using Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Queries;

public sealed record AccountOperationQuery(AccountId[] AccountIds)
{
    public sealed class Builder
    {
        private readonly List<AccountId> _ids = [];

        public AccountOperationQuery Build()
        {
            return new AccountOperationQuery(_ids.ToArray());
        }

        public Builder WithAccountId(AccountId id)
        {
            _ids.Add(id);
            return this;
        }
    }
}
