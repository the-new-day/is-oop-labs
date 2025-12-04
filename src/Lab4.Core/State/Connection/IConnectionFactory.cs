using DirectoryNode = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.DirectoryNode;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.State.Connection;

public interface IConnectionFactory
{
    IConnection Create(DirectoryNode rootDirectory);
}
