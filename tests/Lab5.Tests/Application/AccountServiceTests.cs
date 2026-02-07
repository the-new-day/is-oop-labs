using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Queries;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts.Operations;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Services;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Sessions;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.ValueObjects;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Application;

public class AccountServiceTests
{
    private readonly IPersistenceContext _context;

    private readonly AccountService _accountService;

    private readonly Guid _validSessionKey;

    private readonly AccountId _accountId;

    public AccountServiceTests()
    {
        _context = Substitute.For<IPersistenceContext>();
        _accountService = new AccountService(_context);
        _validSessionKey = Guid.NewGuid();
        _accountId = new AccountId(1);
    }

    [Fact]
    public void WithdrawMoney_WhenSufficientBalance_ShouldReturnSuccess()
    {
        // Arrange
        var account = new Account(
            _accountId,
            new Money(1000),
            new PinCode("1234"));

        SetupValidUserSessionAndAccount(account);

        // Act
        WithdrawMoney.Response result = _accountService.WithdrawMoney(
            new WithdrawMoney.Request(500, _validSessionKey));

        // Assert
        Assert.IsType<WithdrawMoney.Response.Success>(result);
        Assert.Equal(500, account.Balance.Value);
    }

    [Fact]
    public void WithdrawMoney_WhenInsufficientBalance_ShouldReturnNotEnoughMoney()
    {
        // Arrange
        var account = new Account(
            _accountId,
            new Money(100),
            new PinCode("1234"));

        SetupValidUserSessionAndAccount(account);

        // Act
        WithdrawMoney.Response result = _accountService.WithdrawMoney(
            new WithdrawMoney.Request(500, _validSessionKey));

        // Assert
        Assert.IsType<WithdrawMoney.Response.NotEnoughMoney>(result);
        Assert.Equal(100, account.Balance.Value);
    }

    [Fact]
    public void ReplenishMoney_ShouldIncreaseBalance()
    {
        // Arrange
        var account = new Account(
            _accountId,
            new Money(1000),
            new PinCode("1234"));

        SetupValidUserSessionAndAccount(account);

        // Act
        ReplenishMoney.Response result = _accountService.ReplenishMoney(
            new ReplenishMoney.Request(500, _validSessionKey));

        // Assert
        Assert.IsType<ReplenishMoney.Response.Success>(result);
        Assert.Equal(1500, account.Balance.Value);
    }

    private void SetupValidUserSessionAndAccount(Account account)
    {
        var session = new Session(new UserSession());

        _context.Sessions
            .Query(Arg.Any<SessionQuery>())
            .Returns(new[] { session }.AsQueryable());

        _context.SessionAccounts
            .Query(Arg.Any<SessionAccountQuery>())
            .Returns(new[] { _accountId }.AsQueryable());

        _context.Accounts
            .Query(Arg.Any<AccountQuery>())
            .Returns(new[] { account }.AsQueryable());
    }
}
