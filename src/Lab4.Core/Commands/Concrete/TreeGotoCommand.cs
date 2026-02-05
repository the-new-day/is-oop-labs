using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.State;
using Itmo.ObjectOrientedProgramming.Lab4.Core.State.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete;

public class TreeGotoCommand : ICommand
{
    private readonly Nodes.Directory _path;
    
    private readonly IConnection _connection;

    public TreeGotoCommand(IConnection connection, Nodes.Directory path)
    {
        _path = path;
        _connection = connection;
    }

    public CommandExecutionResult Execute(IFileSystem fileSystem)
    {
        ConnectionChangeDirectoryResult result = _connection.TryChangeDirectory(_path);

        return result is ConnectionChangeDirectoryResult.Success
            ? new CommandExecutionResult.Success()
            : new CommandExecutionResult.Failure();
    }
}
