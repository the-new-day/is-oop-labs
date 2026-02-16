using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Http.Models;

public sealed class CreateAccountRequest
{
    [Required]
    public decimal Balance { get; set; }

    [NotNull]
    [Required]
    public string? PinCode { get; set; }

    [Required]
    public Guid SessionKey { get; set; }
}
