namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public interface ICommandFactory
{
    ICommand CreateCommand(
        string commandName,
        IReadOnlyDictionary<string, string> parameters,
        IReadOnlyDictionary<string, string> flags);
}
