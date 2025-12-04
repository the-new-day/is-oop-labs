using FileNode = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.FileNode;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public interface IFileContentDisplayer
{
    void Display(Stream fileStream, FileNode file);
}
