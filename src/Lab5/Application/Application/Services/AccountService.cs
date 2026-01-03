using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Queries;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts.Operations;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Mapping;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.AccountOperations;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts.Results;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Sessions;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.ValueObjects;
using System.Diagnostics;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Services;

internal sealed class AccountService : IAccountService
{
    private readonly IPersistenceContext _context;

    public AccountService(IPersistenceContext context)
    {
        _context = context;
    }

    public CheckBalance.Response CheckBalance(CheckBalance.Request request)
    {
        Session? session = FindSession(request.SessionKey);

        if (session is null)
            return new CheckBalance.Response.InvalidSessionKey();

        if (session.Type.CanCheckBalance() is false)
            return new CheckBalance.Response.OperationIsNotAllowed();

        AccountId accountId = FindAccountId(session.Key);

        if (accountId == AccountId.Default)
            return new CheckBalance.Response.InvalidSessionKey();

        Account account = _context.Accounts
            .Query(new AccountQuery.Builder().WithId(accountId).Build())
            .Single();

        _context.AccountOperations.Add(new Operation(accountId, OperationType.BalanceCheck));
        return new CheckBalance.Response.Success(account.Balance.MapToDto());
    }

    public CreateAccount.Response CreateAccount(CreateAccount.Request request)
    {
        Session? session = FindSession(request.SessionKey);

        if (session is null)
            return new CreateAccount.Response.InvalidSessionKey();

        if (session.Type.CanCreateAccounts() is false)
            return new CreateAccount.Response.OperationIsNotAllowed();

        var account = new Account(
            AccountId.Default,
            new Money(request.Balance),
            new PinCode(request.PinCode));
        account = _context.Accounts.Add(account);

        _context.AccountOperations.Add(new Operation(account.Id, OperationType.Creation));
        return new CreateAccount.Response.Success(account.MapToDto());
    }

    public ReplenishMoney.Response ReplenishMoney(ReplenishMoney.Request request)
    {
        Session? session = FindSession(request.SessionKey);

        if (session is null)
            return new ReplenishMoney.Response.InvalidSessionKey();

        if (session.Type.CanReplenishMoney() is false)
            return new ReplenishMoney.Response.OperationIsNotAllowed();

        AccountId accountId = FindAccountId(session.Key);

        if (accountId == AccountId.Default)
            return new ReplenishMoney.Response.InvalidSessionKey();

        Account account = _context.Accounts
            .Query(new AccountQuery.Builder().WithId(accountId).Build())
            .Single();

        account.Replenish(new Money(request.Amount));
        _context.AccountOperations.Add(new Operation(accountId, OperationType.MoneyReplenishment));
        return new ReplenishMoney.Response.Success();
    }

    public WithdrawMoney.Response WithdrawMoney(WithdrawMoney.Request request)
    {
        Session? session = FindSession(request.SessionKey);

        if (session is null)
            return new WithdrawMoney.Response.InvalidSessionKey();

        if (session.Type.CanWithdrawMoney() is false)
            return new WithdrawMoney.Response.OperationIsNotAllowed();

        AccountId accountId = FindAccountId(session.Key);

        if (accountId == AccountId.Default)
            return new WithdrawMoney.Response.InvalidSessionKey();

        Account account = _context.Accounts
            .Query(new AccountQuery.Builder().WithId(accountId).Build())
            .Single();

        AccountWithdrawalResult result = account.Withdraw(new Money(request.Amount));

        _context.AccountOperations.Add(new Operation(accountId, OperationType.MoneyWithdrawal));

        return result switch
        {
            AccountWithdrawalResult.Success => new WithdrawMoney.Response.Success(),
            AccountWithdrawalResult.NotEnoughMoney => new WithdrawMoney.Response.NotEnoughMoney(),
            _ => throw new UnreachableException(),
        };
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
