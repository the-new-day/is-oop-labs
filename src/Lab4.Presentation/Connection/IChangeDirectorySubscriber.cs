namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Connection;

public interface IChangeDirectorySubscriber
{
    void OnChangeDirectory(Core.Nodes.Directory newDirectory);
}
