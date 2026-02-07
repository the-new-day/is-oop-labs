using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete;

public class TreeGotoCommand : ICommand
{
    private readonly Nodes.Directory _path;

    private readonly IFileSystemConnection _connection;

    public TreeGotoCommand(IFileSystemConnection connection, Nodes.Directory path)
    {
        _path = path;
        _connection = connection;
    }

    public CommandExecutionResult Execute(IFileSystem fileSystem)
    {
        UnixPath newAbsolutePath = _connection.CurrentDirectory.Combine(_path.Path);

        if (!fileSystem.IsDirectory(newAbsolutePath))
            return new CommandExecutionResult.Failure("Directory not found");

        _connection.ChangeDirectory(new Nodes.Directory(newAbsolutePath));
        return new CommandExecutionResult.Success();
    }
}
