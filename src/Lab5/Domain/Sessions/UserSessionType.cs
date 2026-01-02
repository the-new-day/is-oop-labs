namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Sessions;

public sealed class UserSessionType : ISessionType
{
    public SessionType Type => SessionType.User;

    public bool CanCreateAccounts() => false;

    public bool CanCheckBalance() => true;

    public bool CanWithdrawMoney() => true;

    public bool CanReplenishMoney() => true;
}