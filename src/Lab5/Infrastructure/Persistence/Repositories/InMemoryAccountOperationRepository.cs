using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Queries;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.AccountOperations;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Persistence.Repositories;

internal sealed class InMemoryAccountOperationRepository : IAccountOperationRepository
{
    private readonly Dictionary<AccountId, Operation> _values = [];

    public Operation Add(Operation operation)
    {
        operation = new Operation(
            operation.AccountId,
            operation.Type);

        _values.Add(operation.AccountId, operation);
        return operation;
    }

    public IEnumerable<Operation> Query(AccountOperationQuery query)
    {
        return _values.Values
            .Where(x => query.AccountIds is [] || query.AccountIds.Contains(x.AccountId));
    }
}
