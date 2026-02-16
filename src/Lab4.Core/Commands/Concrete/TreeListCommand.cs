using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Directory = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.Directory;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete;

public class TreeListCommand : ICommand
{
    public Directory Path { get; }

    public int MaxDepth { get; }

    public ITreeListDisplayer Displayer { get; }

    public TreeListCommand(Directory path, int maxDepth, ITreeListDisplayer displayer)
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
