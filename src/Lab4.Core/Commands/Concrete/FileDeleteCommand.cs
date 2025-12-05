using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.State.Connection;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete;

public class FileDeleteCommand : ICommand
{
    private readonly IFile _path;

    public FileDeleteCommand(IFile path)
    {
        _path = path;
    }

    public CommandExecutionResult Execute(IConnection connection)
    {
        FileSystemResult result = connection.FileSystem.DeleteFile(_path);

        return result is FileSystemResult.Success
            ? new CommandExecutionResult.Success()
            : new CommandExecutionResult.Failure();
    }
}