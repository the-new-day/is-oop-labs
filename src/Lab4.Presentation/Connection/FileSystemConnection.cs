using Itmo.ObjectOrientedProgramming.Lab4.Core;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Connection.State;
using Directory = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.Directory;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Connection;

public class FileSystemConnection : IFileSystemConnection
{
    public IFileSystem FileSystem { get; }

    public Directory RootDirectory { get; }

    public Directory CurrentDirectory { get; private set; }

    public IConnectionState State { get; private set; }

    private readonly List<IChangeDirectorySubscriber> _subscribers = new();

    public FileSystemConnection(
        IFileSystem fileSystem,
        Directory rootDirectory,
        IConnectionState state)
    {
        FileSystem = fileSystem;
        RootDirectory = rootDirectory;
        CurrentDirectory = rootDirectory;
        State = state;
    }

    public IChangeDirectorySubscription Subscribe(IChangeDirectorySubscriber subscriber)
    {
        _subscribers.Add(subscriber);
        return new Subscription(this, subscriber);
    }

    public void UpdateState(IConnectionState state)
    {
        State = state;
    }

    public void ChangeDirectory(Directory newDirectory)
    {
        CurrentDirectory = newDirectory;

        foreach (IChangeDirectorySubscriber subscriber in _subscribers)
            subscriber.OnChangeDirectory(newDirectory);
    }

    private class Subscription(
        FileSystemConnection connection,
        IChangeDirectorySubscriber subscriber) : IChangeDirectorySubscription
    {
        public void Unsubscribe()
        {
            connection._subscribers.Remove(subscriber);
        }
    }
}
