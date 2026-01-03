using Itmo.ObjectOrientedProgramming.Lab5.Domain.AccountOperations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Queries;

public sealed record AccountOperationQuery(OperationId[] OperationIds)
{
    public sealed class Builder
    {
        private readonly List<OperationId> _operationIds = [];

        public AccountOperationQuery Build()
        {
            return new AccountOperationQuery(_operationIds.ToArray());
        }

        public Builder WithId(OperationId id)
        {
            _operationIds.Add(id);
            return this;
        }
    }
}
