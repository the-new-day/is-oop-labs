using Itmo.ObjectOrientedProgramming.Lab4.Core;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.State;

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
        return new DisconnectParser()
            .AddNext(new FileCopyParser())
            .AddNext(new FileDeleteParser())
            .AddNext(new FileMoveParser())
            .AddNext(new FileRenameParser())
            .AddNext(new FileShowParser(_supportedFileShowModes))
            .AddNext(new TreeGotoParser(_connection))
            .AddNext(new TreeListParser(_treeListDisplayer));
    }
}
