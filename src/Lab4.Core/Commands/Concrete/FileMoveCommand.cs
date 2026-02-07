using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete;

public class FileMoveCommand : ICommand
{
    public Nodes.File SourcePath { get; }

    public Nodes.Directory DestinationPath { get; }

    public FileMoveCommand(Nodes.File sourcePath, Nodes.Directory destinationPath)
    {
        SourcePath = sourcePath;
        DestinationPath = destinationPath;
    }

    public CommandExecutionResult Execute(IFileSystem fileSystem)
    {
        FileSystemResult result = fileSystem.MoveFile(SourcePath, DestinationPath);

        if (result is FileSystemResult.Failure failure)
            return new CommandExecutionResult.Failure(failure.Message);

        return new CommandExecutionResult.Success();
    }
}
