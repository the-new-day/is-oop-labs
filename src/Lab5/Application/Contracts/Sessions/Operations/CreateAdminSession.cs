using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Sessions.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Sessions.Operations;

public static class CreateAdminSession
{
    public readonly record struct Request(string SystemPassword);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(SessionDto Session) : Response;

        public sealed record WrongSystemPassword : Response;
    }
}
