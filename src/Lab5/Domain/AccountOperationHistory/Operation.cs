using Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.AccountOperationHistory;

public record Operation(OperationId OperationId, AccountId AccountId, OperationType Type);
