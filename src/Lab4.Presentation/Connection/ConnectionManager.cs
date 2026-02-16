using Itmo.ObjectOrientedProgramming.Lab4.Core;
using Directory = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.Directory;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Connection;

public class ConnectionManager
{
    public IFileSystemConnection? Connection { get; private set; }

    public void Connect(Directory path, IConnectionFactory connectionFactory)
    {
        Connection = connectionFactory.Create(path);
    }

    public void Disconnect()
    {
        Connection = null;
    }
}
