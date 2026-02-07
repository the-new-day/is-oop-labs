using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete;

public class FileRenameCommand : ICommand
{
    public Nodes.File Path { get; }

    public string Name { get; }

    public FileRenameCommand(Nodes.File path, string name)
    {
        Path = path;
        Name = name;
    }

    public CommandExecutionResult Execute(IFileSystem fileSystem)
    {
        FileSystemResult result = fileSystem.RenameFile(Path, Name);

        if (result is FileSystemResult.Failure failure)
            return new CommandExecutionResult.Failure(failure.Message);

        return new CommandExecutionResult.Success();
    }
}