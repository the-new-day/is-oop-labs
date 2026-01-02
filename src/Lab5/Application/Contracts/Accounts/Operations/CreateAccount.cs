using Itmo.ObjectOrientedProgramming.Lab5.Domain.Sessions;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts.Operations;

public static class CreateAccount
{
    public readonly record struct Request(Money Balance, PinCode PinCode, SessionKey SessionKey);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success : Response;

        public sealed record UserIsNotPermittedToCreateAccounts : Response;
    }
}
