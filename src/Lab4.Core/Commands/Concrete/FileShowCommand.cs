using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.State.Connection;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete;

public class FileShowCommand : ICommand
{
    private readonly IFileContentDisplayer _contentDisplayer;

    private readonly IFile _path;

    public FileShowCommand(IFile path, IFileContentDisplayer contentDisplayer)
    {
        _path = path;
        _contentDisplayer = contentDisplayer;
    }

    public CommandExecutionResult Execute(IConnection connection)
    {
        FileReadOpeningResult result = connection.FileSystem.OpenRead(_path);

        if (result is FileReadOpeningResult.Success success)
        {
            _contentDisplayer.Display(success.FileStream);
            return new CommandExecutionResult.Success();
        }

        return new CommandExecutionResult.Failure();
    }
}
