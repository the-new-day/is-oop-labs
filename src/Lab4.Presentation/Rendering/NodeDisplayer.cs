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

    public void Display(Core.Nodes.Directory node, int depth)
    {
        _outputRenderer.Render(_nodeDisplayFormatter.Format(node, depth));
    }

    public void Display(Core.Nodes.File node, int depth)
    {
        _outputRenderer.Render(_nodeDisplayFormatter.Format(node, depth));
    }
}
