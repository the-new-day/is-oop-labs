using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Directory = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.Directory;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests.Stubs;

public class StubDisplayer : ITreeListDisplayer
{
    public void Display(Directory rootDirectory, int maxDepth, IFileSystem fileSystem) { }
}
