namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public record struct Message(string Header, string Body, MessageImportanceLevel ImportanceLevel);
