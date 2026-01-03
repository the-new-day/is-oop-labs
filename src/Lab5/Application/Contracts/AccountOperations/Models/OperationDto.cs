namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.AccountOperations.Models;

public sealed record OperationDto(long AccountId, OperationTypeDto OperationType);
