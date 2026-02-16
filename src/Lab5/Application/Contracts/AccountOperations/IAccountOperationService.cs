using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.AccountOperations.Operations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.AccountOperations;

public interface IAccountOperationService
{
    CheckOperationHistory.Response CheckHistory(CheckOperationHistory.Request request);
}
