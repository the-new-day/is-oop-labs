namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing;

public record CommandTokens(IEnumerable<string> Arguments, Dictionary<string, string> Flags);
