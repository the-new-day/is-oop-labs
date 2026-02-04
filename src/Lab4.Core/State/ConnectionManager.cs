using Itmo.ObjectOrientedProgramming.Lab4.Core.State.Connection;
using Directory = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.Directory;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.State;

public class ConnectionManager
{
    public IConnection? CurrentConnection { get; private set; }

    public void Connect(Directory rootDirectory, IConnectionFactory connectionFactory)
    {
        CurrentConnection = connectionFactory.Create(rootDirectory);
    }

    public void Disconnect()
    {
        CurrentConnection = null;
    }
}
