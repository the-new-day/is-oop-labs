using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete;

public class TreeGotoCommand : ICommand
{
    public Nodes.Directory Path { get; }

    public IFileSystemConnection Connection { get; }

    public TreeGotoCommand(IFileSystemConnection connection, Nodes.Directory path)
    {
        Path = path;
        Connection = connection;
    }

    public CommandExecutionResult Execute(IFileSystem fileSystem)
    {
        UnixPath newAbsolutePath = Connection.CurrentDirectory.Combine(Path.Path);

        if (!fileSystem.IsDirectory(newAbsolutePath))
            return new CommandExecutionResult.Failure("Directory not found");

        Connection.ChangeDirectory(new Nodes.Directory(newAbsolutePath));
        return new CommandExecutionResult.Success();
    }
}
