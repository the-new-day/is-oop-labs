using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.State.Connection;
using Itmo.ObjectOrientedProgramming.Lab4.Core.State.Connection.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete;

public class TreeGotoCommand : ICommand
{
    private readonly Nodes.Directory _path;

    public TreeGotoCommand(Nodes.Directory path)
    {
        _path = path;
    }

    public CommandExecutionResult Execute(IConnection connection)
    {
        ConnectionChangeDirectoryResult result = connection.TryChangeDirectory(_path);

        return result is ConnectionChangeDirectoryResult.Success
            ? new CommandExecutionResult.Success()
            : new CommandExecutionResult.Failure();
    }
}
