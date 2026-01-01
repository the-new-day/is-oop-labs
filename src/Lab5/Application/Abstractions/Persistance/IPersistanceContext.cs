using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistance.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions;

public interface IPersistanceContext
{
    IAccountOperationRepository AccountOperations { get; }

    IAccountRepository Accounts { get; }

    ISessionRepository Sessions { get; }
}
