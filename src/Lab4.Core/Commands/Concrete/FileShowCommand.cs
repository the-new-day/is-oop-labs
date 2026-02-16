using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Results;
using System.Diagnostics;
using File = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete;

public class FileShowCommand : ICommand
{
    public IFileContentDisplayer ContentDisplayer { get; }

    public File Path { get; }

    public FileShowCommand(File path, IFileContentDisplayer contentDisplayer)
    {
        Path = path;
        ContentDisplayer = contentDisplayer;
    }

    public CommandExecutionResult Execute(IFileSystem fileSystem)
    {
        FileReadOpeningResult result = fileSystem.OpenRead(Path);

        if (result is FileReadOpeningResult.Success success)
        {
            ContentDisplayer.Display(success.FileStream);
            return new CommandExecutionResult.Success();
        }
        else if (result is FileReadOpeningResult.Failure failure)
        {
            return new CommandExecutionResult.Failure(failure.Message);
        }

        throw new UnreachableException();
    }
}
