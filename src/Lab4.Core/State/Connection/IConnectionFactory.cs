using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.State.Connection;

public interface IConnectionFactory
{
    IConnection Create(IPath rootPath);
}
