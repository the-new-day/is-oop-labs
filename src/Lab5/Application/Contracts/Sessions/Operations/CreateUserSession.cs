using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Sessions.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Sessions.Operations;

public static class CreateUserSession
{
    public readonly record struct Request(long AccountId, string PinCode);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(SessionDto Session) : Response;

        public sealed record AccountNotFound : Response;

        public sealed record WrongPinCode : Response;
    }
}
