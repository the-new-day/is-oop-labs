using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.State.Connection;

public interface IConnection
{
    IFileSystem FileSystem { get; }

    IPath Address { get; }
}
