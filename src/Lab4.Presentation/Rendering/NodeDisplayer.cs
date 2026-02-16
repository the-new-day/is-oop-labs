using Directory = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.Directory;
using File = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Rendering;

public class NodeDisplayer
{
    private readonly IOutputRenderer _outputRenderer;

    private readonly INodeDisplayFormatter _nodeDisplayFormatter;

    public NodeDisplayer(
        IOutputRenderer outputRenderer,
        INodeDisplayFormatter nodeDisplayFormatter)
    {
        _outputRenderer = outputRenderer;
        _nodeDisplayFormatter = nodeDisplayFormatter;
    }

    public void Display(Directory node, int depth)
    {
        _outputRenderer.Render(_nodeDisplayFormatter.Format(node, depth));
    }

    public void Display(File node, int depth)
    {
        _outputRenderer.Render(_nodeDisplayFormatter.Format(node, depth));
    }
}
