using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Itmo.ObjectOrientedProgramming.Lab4.Core.State.Connection;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.State;

public class StateManager
{
    public IConnection? CurrentConnection { get; private set; }

    public void Connect(IPath rootPath, IConnectionFactory connectionFactory)
    {
        CurrentConnection = connectionFactory.Create(rootPath);
    }

    public void Disconnect()
    {
        CurrentConnection = null;
    }
}
