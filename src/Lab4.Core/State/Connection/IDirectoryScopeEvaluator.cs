namespace Itmo.ObjectOrientedProgramming.Lab4.Core.State.Connection;

public interface IDirectoryScopeEvaluator
{
    bool IsNodeWithinRootScore(Nodes.Directory rootDirectory, Nodes.IFileSystemNode node);
}
