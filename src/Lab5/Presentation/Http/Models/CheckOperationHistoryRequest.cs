using System.ComponentModel.DataAnnotations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Http.Models;

public sealed class CheckOperationHistoryRequest
{
    [Required]
    public Guid SessionKey { get; set; }
}
