using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Queries;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.AccountOperations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistance.Repositories;

public interface IAccountOperationRepository
{
    Operation Add(Operation operation);

    IEnumerable<Operation> Query(AccountOperationQuery query);
}
