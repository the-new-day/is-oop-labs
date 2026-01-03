using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Persistence;

internal sealed class PersistenceContext : IPersistenceContext
{
    public IAccountOperationRepository AccountOperations { get; }

    public IAccountRepository Accounts { get; }

    public ISessionRepository Sessions { get; }

    public ISessionAccountRepository SessionAccounts { get; }

    public PersistenceContext(
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
