using Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Renderering;

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

    public void Display(IDirectory node, int depth)
    {
        _outputRenderer.Render(_nodeDisplayFormatter.Format(node, depth));
    }

    public void Display(IFile node, int depth)
    {
        _outputRenderer.Render(_nodeDisplayFormatter.Format(node, depth));
    }
}
