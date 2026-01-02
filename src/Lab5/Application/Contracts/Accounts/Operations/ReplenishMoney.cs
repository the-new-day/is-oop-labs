namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts.Operations;

public static class ReplenishMoney
{
    public readonly record struct Request(Guid SessionKey, decimal Amount);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success : Response;

        public sealed record InvalidSessionKey : Response;

        public sealed record OperationIsNotAllowed : Response;
    }
}
