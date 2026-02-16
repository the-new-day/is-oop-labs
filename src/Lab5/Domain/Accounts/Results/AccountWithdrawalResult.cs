namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts.Results;

public abstract record AccountWithdrawalResult
{
    private AccountWithdrawalResult() { }

    public sealed record Success : AccountWithdrawalResult;

    public sealed record NotEnoughMoney : AccountWithdrawalResult;
}
