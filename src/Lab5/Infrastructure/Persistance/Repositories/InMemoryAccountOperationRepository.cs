using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistance.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Queries;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.AccountOperations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Persistance.Repositories;

public sealed class InMemoryAccountOperationRepository : IAccountOperationRepository
{
    private readonly Dictionary<OperationId, Operation> _values = [];

    public Operation Add(Operation operation)
    {
        operation = new Operation(
            new OperationId(_values.Count + 1),
            operation.AccountId,
            operation.Type);

        _values.Add(operation.OperationId, operation);
        return operation;
    }

    public IEnumerable<Operation> Query(AccountOperationQuery query)
    {
        return _values.Values
            .Where(x => query.OperationIds is [] || query.OperationIds.Contains(x.OperationId));
    }
}
