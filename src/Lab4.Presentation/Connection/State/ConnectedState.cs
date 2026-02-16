using Itmo.ObjectOrientedProgramming.Lab4.Core;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Connection.State;

public class ConnectedState : IConnectionState
{
    private readonly IFileSystemConnection _connection;

    private readonly ITreeListDisplayer _treeListDisplayer;

    private readonly Dictionary<string, IFileContentDisplayer> _supportedFileShowModes;

    public ConnectedState(
        IFileSystemConnection connection,
        ITreeListDisplayer treeListDisplayer,
        Dictionary<string, IFileContentDisplayer> supportedFileShowModes)
    {
        _connection = connection;
        _treeListDisplayer = treeListDisplayer;
        _supportedFileShowModes = supportedFileShowModes;
    }

    public ParserHandler GetParserHandler()
    {
        ParserHandler fileChain = new CommandNodeParser("copy", new FileCopyParser())
            .AddNext(new CommandNodeParser("delete", new FileDeleteParser()))
            .AddNext(new CommandNodeParser("move", new FileMoveParser()))
            .AddNext(new CommandNodeParser("rename", new FileRenameParser()))
            .AddNext(new CommandNodeParser("show", new FileShowParser(_supportedFileShowModes)));

        ParserHandler treeChain = new CommandNodeParser("goto", new TreeGotoParser(_connection))
            .AddNext(new CommandNodeParser("list", new TreeListParser(_treeListDisplayer)));

        return new CommandNodeParser("disconnect", new DisconnectParser())
            .AddNext(new CommandNodeParser("file", fileChain))
            .AddNext(new CommandNodeParser("tree", treeChain));
    }
}
