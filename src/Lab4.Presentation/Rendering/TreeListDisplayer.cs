using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;
using Directory = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.Directory;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Rendering;

public class TreeListDisplayer : ITreeListDisplayer
{
    private readonly INodeDisplayFormatter _formatter;

    private readonly IOutputRenderer _renderer;

    public TreeListDisplayer(INodeDisplayFormatter formatter, IOutputRenderer renderer)
    {
        _formatter = formatter;
        _renderer = renderer;
    }

    public void Display(Directory rootDirectory, int maxDepth, IFileSystem fileSystem)
    {
        DisplayDirectory(rootDirectory, 0, maxDepth, fileSystem);
    }

    private void DisplayDirectory(Directory directory, int currentDepth, int maxDepth, IFileSystem fileSystem)
    {
        if (currentDepth > maxDepth) return;

        DirectoryContentsResult result = fileSystem.GetContents(directory);
        if (result is DirectoryContentsResult.Success success)
        {
            foreach (IFileSystemNode node in success.Nodes)
            {
                if (fileSystem.IsDirectory(node.Path))
                {
                    DisplayDirectory(new Directory(node.Path), currentDepth + 1, maxDepth, fileSystem);
                }
                else
                {
                    DisplayNode(node, currentDepth);
                }
            }
        }

        if (result is DirectoryContentsResult.Failure failure)
        {
            throw new ArgumentException(
                $"Directory {directory.Path.Value} contents can't be displayed: {failure.Message}",
                nameof(directory));
        }
    }

    private void DisplayNode(IFileSystemNode node, int depth)
    {
        _renderer.RenderLine(_formatter.Format(node, depth));
    }
}
