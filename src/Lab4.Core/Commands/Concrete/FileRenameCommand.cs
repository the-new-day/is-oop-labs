using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.State.Connection;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete;

public class FileRenameCommand : ICommand
{
    private readonly IFile _path;

    private readonly string _name;

    public FileRenameCommand(IFile path, string name)
    {
        _path = path;
        _name = name;
    }

    public CommandExecutionResult Execute(IConnection connection)
    {
        FileSystemResult result = connection.FileSystem.RenameFile(_path, _name);

        return result is FileSystemResult.Success
            ? new CommandExecutionResult.Success()
            : new CommandExecutionResult.Failure();
    }
}