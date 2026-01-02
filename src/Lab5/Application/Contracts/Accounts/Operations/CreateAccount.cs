namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts.Operations;

public static class CreateAccount
{
    public readonly record struct Request(decimal Balance, string PinCode, Guid SessionKey);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success : Response;

        public sealed record UserIsNotPermittedToCreateAccounts : Response;
    }
}
