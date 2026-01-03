using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.AccountOperations.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.AccountOperations.Operations;

public static class CheckOperationHistory
{
    public readonly record struct Request(Guid SessionKey);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(OperationHistoryDto OperationHistory) : Response;

        public sealed record InvalidSessionKey : Response;

        public sealed record OperationIsNotAllowed : Response;
    }
}
