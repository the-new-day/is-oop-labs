using Itmo.ObjectOrientedProgramming.Lab4.Core;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.State;
using Directory = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.Directory;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests.Mocks;

public class StubConnection : IFileSystemConnection
{
    public IFileSystem FileSystem => new StubFileSystem();

    public Directory RootDirectory => new Directory(new UnixPath("/"));

    public Directory CurrentDirectory { get; private set; } = new Directory(new UnixPath("/"));

    public IConnectionState State => new StubConnectionState();

    public void UpdateState(IConnectionState state) { }

    public void ChangeDirectory(Directory newDirectory)
    {
        CurrentDirectory = newDirectory;
    }
}