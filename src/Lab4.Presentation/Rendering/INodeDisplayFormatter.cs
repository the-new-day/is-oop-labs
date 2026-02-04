using Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Rendering;

public interface INodeDisplayFormatter
{
    string Format(IFileSystemNode node, int depth);
}
