using Itmo.ObjectOrientedProgramming.Lab4.Core.State.Connection;
using DirectoryNode = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.DirectoryNode;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.State;

public class StateManager
{
    public IConnection? CurrentConnection { get; private set; }

    public void Connect(DirectoryNode rootDirectory, IConnectionFactory connectionFactory)
    {
        CurrentConnection = connectionFactory.Create(rootDirectory);
    }

    public void Disconnect()
    {
        CurrentConnection = null;
    }
}
