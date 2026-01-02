using Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts.Operations;

public static class CheckBalance
{
    public readonly record struct Request(AccountId AccountId);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(Money Amount) : Response;

        public sealed record AccountNotFound : Response;
    }
}
