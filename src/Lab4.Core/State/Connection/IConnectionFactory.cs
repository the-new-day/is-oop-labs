using IDirectory = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.IDirectory;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.State.Connection;

public interface IConnectionFactory
{
    IConnection Create(IDirectory rootDirectory);
}
