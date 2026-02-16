using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Queries;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.AccountOperations;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.AccountOperations.Models;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.AccountOperations.Operations;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Mapping;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Services;

internal sealed class AccountOperationService : IAccountOperationService
{
    private readonly IPersistenceContext _context;

    public AccountOperationService(IPersistenceContext context)
    {
        _context = context;
    }

    public CheckOperationHistory.Response CheckHistory(CheckOperationHistory.Request request)
    {
        Session? session = FindSession(request.SessionKey);

        if (session is null)
            return new CheckOperationHistory.Response.InvalidSessionKey();

        if (session.Type.CanCheckBalance() is false)
            return new CheckOperationHistory.Response.OperationIsNotAllowed();

        AccountId accountId = FindAccountId(session.Key);

        if (accountId == AccountId.Default)
            return new CheckOperationHistory.Response.InvalidSessionKey();

        OperationDto[] operations = _context
            .AccountOperations
            .Query(new AccountOperationQuery.Builder().WithAccountId(accountId).Build())
            .Select(op => op.MapToDto())
            .ToArray();

        return new CheckOperationHistory.Response.Success(new OperationHistoryDto(operations));
    }

    private Session? FindSession(Guid requestSessionKey)
    {
        var sessionKey = new SessionKey(requestSessionKey);
        return _context.Sessions
            .Query(new SessionQuery.Builder().WithKey(sessionKey).Build())
            .SingleOrDefault();
    }

    private AccountId FindAccountId(SessionKey sessionKey)
    {
        return _context.SessionAccounts
            .Query(new SessionAccountQuery.Builder().WithKey(sessionKey).Build())
            .SingleOrDefault();
    }
}