using Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.AccountOperations;

public record Operation(OperationId OperationId, AccountId AccountId, OperationType Type);
