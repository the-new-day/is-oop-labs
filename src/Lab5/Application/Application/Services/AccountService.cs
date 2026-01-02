using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Queries;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts.Operations;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Mapping;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Services;

public sealed class AccountService : IAccountService
{
    private readonly IPersistanceContext _context;

    public AccountService(IPersistanceContext context)
    {
        _context = context;
    }

    public CheckBalance.Response CheckBalance(CheckBalance.Request request)
    {
        var sessionKey = new SessionKey(request.SessionKey);

        Session? session = _context.Sessions
            .Query(new SessionQuery.Builder().WithKey(sessionKey).Build())
            .SingleOrDefault();

        if (session is null)
            return new CheckBalance.Response.InvalidSessionKey();

        if (session.Type.CanCheckBalance() is false)
            return new CheckBalance.Response.OperationIsNotAllowed();

        AccountId accountId = _context.SessionAccounts
            .Query(new SessionAccountQuery.Builder().WithKey(sessionKey).Build())
            .SingleOrDefault();

        if (accountId == AccountId.Default)
            return new CheckBalance.Response.InvalidSessionKey();

        Account account = _context.Accounts
            .Query(new AccountQuery.Builder().WithId(accountId).Build())
            .Single();

        return new CheckBalance.Response.Success(account.Balance.MapToDto());
    }

    public CreateAccount.Response CreateAccount(CreateAccount.Request request)
    {
        throw new NotImplementedException();
    }

    public ReplenishMoney.Response ReplenishMoney(ReplenishMoney.Request request)
    {
        throw new NotImplementedException();
    }

    public WithdrawMoney.Response WithdrawMoney(WithdrawMoney.Request request)
    {
        throw new NotImplementedException();
    }
}
