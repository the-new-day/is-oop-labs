using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Sessions.Models;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Sessions.Operations;

public static class CreateUserSession
{
    public readonly record struct Request(AccountId AccountId, PinCode PinCode);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(SessionDto Session) : Response;

        public sealed record AccountNotFound : Response;

        public sealed record WrongPinCode : Response;
    }
}
