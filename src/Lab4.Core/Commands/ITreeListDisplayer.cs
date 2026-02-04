using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public interface ITreeListDisplayer
{
    void Display(Nodes.Directory rootDirectory, int maxDepth, IFileSystem fileSystem);
}
