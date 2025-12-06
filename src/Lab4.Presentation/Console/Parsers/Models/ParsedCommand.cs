namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Console.Parsers.Models;

public class ParsedCommand
{
    public string CommandName { get; init; } = string.Empty;

    public IReadOnlyDictionary<int, string> Parameters { get; init; } = new Dictionary<int, string>();

    public IReadOnlyDictionary<string, string> Flags { get; init; } = new Dictionary<string, string>();

    public ParsedCommand()
    {
    }

    public ParsedCommand(
        string commandName,
        IReadOnlyDictionary<int, string> parameters,
        IReadOnlyDictionary<string, string> flags)
    {
        CommandName = commandName;
        Parameters = parameters;
        Flags = flags;
    }
}
