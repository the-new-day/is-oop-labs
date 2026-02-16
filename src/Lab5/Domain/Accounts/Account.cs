using Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts.Results;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;

public sealed class Account
{
    public AccountId Id { get; }

    public Money Balance { get; private set; }

    public PinCode PinCode { get; }

    public Account(AccountId id, Money initialBalance, PinCode pinCode)
    {
        Id = id;
        Balance = initialBalance;
        PinCode = pinCode;
    }

    public AccountWithdrawalResult Withdraw(Money amount)
    {
        if (Balance < amount)
            return new AccountWithdrawalResult.NotEnoughMoney();

        Balance -= amount;
        return new AccountWithdrawalResult.Success();
    }

    public void Replenish(Money amount)
    {
        Balance += amount;
    }
}
