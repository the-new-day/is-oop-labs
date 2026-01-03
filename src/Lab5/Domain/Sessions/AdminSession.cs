namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Sessions;

public sealed class AdminSession : ISessionType
{
    public SessionType Type => SessionType.Admin;

    public bool CanCreateAccounts() => true;

    public bool CanCheckBalance() => false;

    public bool CanWithdrawMoney() => false;

    public bool CanReplenishMoney() => false;

    public bool CanCheckHistory() => false;
}