using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Queries;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.AccountOperations;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Persistence.Repositories;

internal sealed class InMemoryAccountOperationRepository : IAccountOperationRepository
{
    private readonly List<(AccountId, Operation)> _values = [];

    public Operation Add(Operation operation)
    {
        operation = new Operation(
            operation.AccountId,
            operation.Type);

        _values.Add((operation.AccountId, operation));
        return operation;
    }

    public IEnumerable<Operation> Query(AccountOperationQuery query)
    {
        return _values
            .Where(pair => query.AccountIds is [] || query.AccountIds.Contains(pair.Item1))
            .Select(pair => pair.Item2);
    }
}
