using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public interface ITreeListDisplayer
{
    void Display(IDirectory rootDirectory, int maxDepth, IFileSystem fileSystem);
}
