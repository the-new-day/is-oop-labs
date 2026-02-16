using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts.Operations;

public static class CheckBalance
{
    public readonly record struct Request(Guid SessionKey);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(MoneyDto Balance) : Response;

        public sealed record InvalidSessionKey : Response;

        public sealed record OperationIsNotAllowed : Response;
    }
}
