using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete.Data;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.State.Connection;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete;

public class FileShowCommand : CommandBase<FileShowData>
{
    private readonly IFileContentDisplayer _contentDisplayer;

    public FileShowCommand(ICommandDataParser<FileShowData> dataParser, IFileContentDisplayer contentDisplayer)
        : base(dataParser)
    {
        _contentDisplayer = contentDisplayer;
    }

    protected override CommandResult ExecuteWithParsedData(FileShowData data, IConnection connection)
    {
        FileReadOpeningResult result = connection.FileSystem.OpenRead(data.Path);

        if (result is FileReadOpeningResult.Success success)
        {
            _contentDisplayer.Display(success.FileStream, success.File);
            return new CommandResult.Success();
        }

        return new CommandResult.Failure();
    }
}
