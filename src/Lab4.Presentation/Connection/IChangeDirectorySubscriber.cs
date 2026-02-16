using Directory = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.Directory;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Connection;

public interface IChangeDirectorySubscriber
{
    void OnChangeDirectory(Directory newDirectory);
}
