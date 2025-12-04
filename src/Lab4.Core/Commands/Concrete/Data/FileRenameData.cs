using FileNode = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.FileNode;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete.Data;

public record FileRenameData(FileNode Path, string Name);
