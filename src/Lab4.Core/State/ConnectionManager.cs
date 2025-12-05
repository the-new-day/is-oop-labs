using Itmo.ObjectOrientedProgramming.Lab4.Core.State.Connection;
using IDirectory = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.IDirectory;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.State;

public class ConnectionManager
{
    public IConnection? CurrentConnection { get; private set; }

    public void Connect(IDirectory rootDirectory, IConnectionFactory connectionFactory)
    {
        CurrentConnection = connectionFactory.Create(rootDirectory);
    }

    public void Disconnect()
    {
        CurrentConnection = null;
    }
}
