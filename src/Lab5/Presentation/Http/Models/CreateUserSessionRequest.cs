using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Http.Models;

public sealed class CreateUserSessionRequest
{
    [Range(minimum: 1, maximum: long.MaxValue)]
    public long AccountId { get; set; }

    [NotNull]
    [Required]
    public string? PinCode { get; set; }
}
