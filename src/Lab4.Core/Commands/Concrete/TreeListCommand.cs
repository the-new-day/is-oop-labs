using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete;

public class TreeListCommand : ICommand
{
    private readonly Nodes.Directory _path;

    private readonly int _maxDepth;

    private readonly ITreeListDisplayer _displayer;

    public TreeListCommand(Nodes.Directory path, int maxDepth, ITreeListDisplayer displayer)
    {
        _path = path;
        _maxDepth = maxDepth;
        _displayer = displayer;
    }

    public CommandExecutionResult Execute(IFileSystem fileSystem)
    {
        _displayer.Display(_path, _maxDepth, fileSystem);
        return new CommandExecutionResult.Success();
    }
}
