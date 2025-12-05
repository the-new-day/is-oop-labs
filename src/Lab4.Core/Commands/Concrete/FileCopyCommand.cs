using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.State.Connection;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete;

public class FileCopyCommand : ICommand
{
    private readonly IFile _sourcePath;

    private readonly IDirectory _destinationPath;

    public FileCopyCommand(IFile sourcePath, IDirectory destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public CommandExecutionResult Execute(IConnection connection)
    {
        FileSystemResult result = connection.FileSystem.CopyFile(_sourcePath, _destinationPath);

        return result is FileSystemResult.Success
            ? new CommandExecutionResult.Success()
            : new CommandExecutionResult.Failure();
    }
}