using Directory = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.Directory;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.State;

public interface IConnectionFactory
{
    IConnection Create(Directory rootDirectory);
}
