using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;

public interface IFileSystemNodeFactory
{
    IFileSystemNode Create(IPath path);
}
