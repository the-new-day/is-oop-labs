using Itmo.ObjectOrientedProgramming.Lab4.Core;
using Directory = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.Directory;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Connection;

public interface IConnectionFactory
{
    IFileSystemConnection Create(Directory rootDirectory);
}
