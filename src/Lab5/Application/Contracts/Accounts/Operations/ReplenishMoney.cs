using Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts.Operations;

public static class ReplenishMoney
{
    public readonly record struct Request(AccountId AccountId, Money Amount);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success : Response;

        public sealed record AccountNotFound : Response;

        public sealed record NotEnoughMoney : Response;
    }
}
