using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Results;
using Directory = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.Directory;
using File = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete;

public class FileMoveCommand : ICommand
{
    public File SourcePath { get; }

    public Directory DestinationPath { get; }

    public FileMoveCommand(File sourcePath, Directory destinationPath)
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
