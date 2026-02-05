using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing;

public record CommandTokens(ReadOnlyCollection<string> Arguments, ReadOnlyDictionary<string, string> Flags);
