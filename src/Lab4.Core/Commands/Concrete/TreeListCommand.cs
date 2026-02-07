using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete;

public class TreeListCommand : ICommand
{
    public Nodes.Directory Path { get; }

    public int MaxDepth { get; }

    public ITreeListDisplayer Displayer { get; }

    public TreeListCommand(Nodes.Directory path, int maxDepth, ITreeListDisplayer displayer)
    {
        Path = path;
        MaxDepth = maxDepth;
        Displayer = displayer;
    }

    public CommandExecutionResult Execute(IFileSystem fileSystem)
    {
        Displayer.Display(Path, MaxDepth, fileSystem);
        return new CommandExecutionResult.Success();
    }
}
