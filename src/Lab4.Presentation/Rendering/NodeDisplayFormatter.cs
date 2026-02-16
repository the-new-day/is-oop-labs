using Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Rendering;

public class NodeDisplayFormatter : INodeDisplayFormatter
{
    public string Format(IFileSystemNode node, int depth)
    {
        return new string(' ', depth) + node.Name;
    }
}
