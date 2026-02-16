using System.ComponentModel.DataAnnotations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Http.Models;

public sealed class WithdrawMoneyRequest
{
    [Range(minimum: 0, maximum: double.MaxValue)]
    public decimal Amount { get; set; }

    [Required]
    public Guid SessionKey { get; set; }
}
