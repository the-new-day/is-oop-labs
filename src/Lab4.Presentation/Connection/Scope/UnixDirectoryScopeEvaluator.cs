using Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes;
using Directory = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.Directory;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Connection.Scope;

public class UnixDirectoryScopeEvaluator : IDirectoryScopeEvaluator
{
    public bool IsNodeWithinRootScore(Directory rootDirectory, IFileSystemNode node)
    {
        string root = rootDirectory.Path.Value;
        string target = node.Path.Value;

        Console.WriteLine(root);
        Console.WriteLine(target);

        if (root == target) return true;

        string rootWithSlash = root.EndsWith('/') ? root : root + "/";

        return target.StartsWith(rootWithSlash);
    }
}
