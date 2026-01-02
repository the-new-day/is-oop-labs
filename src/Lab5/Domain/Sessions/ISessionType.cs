namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Sessions;

public interface ISessionType
{
    SessionType Type { get; }

    bool CanCreateAccounts();

    bool CanCheckBalance();

    bool CanWithdrawMoney();

    bool CanReplenishMoney();
}
