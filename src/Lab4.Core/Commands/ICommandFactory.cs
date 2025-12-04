namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public interface ICommandFactory
{
    ICommand CreateCommand(string commandName, CommandData commandData);
}
