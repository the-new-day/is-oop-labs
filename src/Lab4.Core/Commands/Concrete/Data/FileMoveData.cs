using DirectoryNode = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.DirectoryNode;
using FileNode = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.FileNode;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete.Data;

public record FileMoveData(FileNode SourcePath, DirectoryNode DestinationPath);
