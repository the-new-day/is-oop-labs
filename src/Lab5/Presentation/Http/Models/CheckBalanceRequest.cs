using System.ComponentModel.DataAnnotations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Http.Models;

public sealed class CheckBalanceRequest
{
    [Required]
    public Guid SessionKey { get; set; }
}
