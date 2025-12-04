namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public abstract record CommandData(
    IReadOnlyDictionary<string, string> Parameters,
    IReadOnlyDictionary<string, string> Flags);
