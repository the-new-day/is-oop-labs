using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.State.Connection;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete;

public class TreeListCommand : ICommand
{
    private readonly IDirectory _path;

    private readonly int _maxDepth;

    private readonly ITreeListDisplayer _displayer;

    public TreeListCommand(IDirectory path, int maxDepth, ITreeListDisplayer displayer)
    {
        _path = path;
        _maxDepth = maxDepth;
        _displayer = displayer;
    }

    public CommandExecutionResult Execute(IConnection connection)
    {
        _displayer.Display(_path, _maxDepth, connection.FileSystem);
        return new CommandExecutionResult.Success();
    }
}
