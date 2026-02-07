using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete;

public class FileDeleteCommand : ICommand
{
    public Nodes.File Path { get; }

    public FileDeleteCommand(Nodes.File path)
    {
        Path = path;
    }

    public CommandExecutionResult Execute(IFileSystem fileSystem)
    {
        FileSystemResult result = fileSystem.DeleteFile(Path);

        if (result is FileSystemResult.Failure failure)
            return new CommandExecutionResult.Failure(failure.Message);

        return new CommandExecutionResult.Success();
    }
}