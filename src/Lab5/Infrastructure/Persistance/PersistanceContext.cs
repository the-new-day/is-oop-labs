using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistance.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Persistance;

internal sealed class PersistanceContext : IPersistanceContext
{
    public IAccountOperationRepository AccountOperations { get; }

    public IAccountRepository Accounts { get; }

    public ISessionRepository Sessions { get; }

    public ISessionAccountRepository SessionAccounts { get; }

    public PersistanceContext(
        IAccountOperationRepository accountOperationRepository,
        IAccountRepository accountRepository,
        ISessionRepository sessionRepository,
        ISessionAccountRepository sessionAccountRepository)
    {
        AccountOperations = accountOperationRepository;
        Accounts = accountRepository;
        Sessions = sessionRepository;
        SessionAccounts = sessionAccountRepository;
    }
}
