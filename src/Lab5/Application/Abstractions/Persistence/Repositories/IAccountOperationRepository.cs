using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Queries;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.AccountOperations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Repositories;

public interface IAccountOperationRepository
{
    Operation Add(Operation operation);

    IEnumerable<Operation> Query(AccountOperationQuery query);
}
