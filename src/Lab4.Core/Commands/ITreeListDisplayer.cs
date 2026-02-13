using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Directory = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.Directory;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public interface ITreeListDisplayer
{
    void Display(Directory rootDirectory, int maxDepth, IFileSystem fileSystem);
}
