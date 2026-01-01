using Itmo.ObjectOrientedProgramming.Lab5.Domain.AccountOperationHistory;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Queries;

public sealed record AccountOperationQuery(OperationId[] OperationIds);
