using Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;
using Directory = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.Directory;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Connection.Scope;

public interface IDirectoryScopeEvaluator
{
    bool IsNodeWithinRootScore(Directory rootDirectory, IFileSystemNode node);
}
