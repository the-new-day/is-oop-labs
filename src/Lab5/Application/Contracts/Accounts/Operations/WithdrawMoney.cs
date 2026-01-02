namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts.Operations;

public static class WithdrawMoney
{
    public readonly record struct Request(Guid SessionKey, decimal Amount);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success : Response;

        public sealed record AccountNotFound : Response;

        public sealed record NotEnoughMoney : Response;

        public sealed record UserIsNotPermittedToWithdrawMoney : Response;
    }
}
