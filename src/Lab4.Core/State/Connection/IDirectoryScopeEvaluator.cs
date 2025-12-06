using Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.State.Connection;

public interface IDirectoryScopeEvaluator
{
    bool IsDirectoryWithinRootScore(IDirectory rootDirectory, IDirectory otherDirectory);
}
