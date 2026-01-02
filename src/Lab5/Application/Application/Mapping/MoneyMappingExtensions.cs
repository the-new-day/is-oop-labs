using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts.Models;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Mapping;

public static class MoneyMappingExtensions
{
    public static MoneyDto MapToDto(this Money money)
        => new MoneyDto(money.Value);
}
