using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions;

public interface IPersistenceContext
{
    IAccountOperationRepository AccountOperations { get; }

    IAccountRepository Accounts { get; }

    ISessionRepository Sessions { get; }

    ISessionAccountRepository SessionAccounts { get; }
}
