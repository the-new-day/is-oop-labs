namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing;

public record CommandTokens(IReadOnlyCollection<string> Arguments, IReadOnlyDictionary<string, string> Flags);
