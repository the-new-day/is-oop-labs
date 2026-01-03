using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.AccountOperations.Models;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.AccountOperations;
using System.Diagnostics;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Mapping;

public static class OperationMappingExtensions
{
    public static OperationTypeDto MapToDto(this OperationType operationType)
    {
        string name = operationType switch
        {
            OperationType.BalanceCheck => "Balance check",
            OperationType.MoneyReplenishment => "Money replenishment",
            OperationType.MoneyWithdrawal => "Money withdrawal",
            OperationType.Creation => "Creation",
            _ => throw new UnreachableException(),
        };

        return new OperationTypeDto(name);
    }

    public static OperationDto MapToDto(this Operation operation)
        => new OperationDto(operation.AccountId.Value, operation.Type.MapToDto());
}
