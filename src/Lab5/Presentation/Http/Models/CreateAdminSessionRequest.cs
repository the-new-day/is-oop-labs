using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Http.Models;

public sealed class CreateAdminSessionRequest
{
    [NotNull]
    [Required]
    public string? SystemPassword { get; set; }
}
