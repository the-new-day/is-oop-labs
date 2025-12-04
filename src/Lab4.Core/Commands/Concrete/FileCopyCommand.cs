using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete.Data;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.State.Connection;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete;

public class FileCopyCommand : CommandBase<FileCopyData>
{
    public FileCopyCommand(ICommandDataParser<FileCopyData> dataParser)
        : base(dataParser)
    {
    }

    protected override CommandResult ExecuteWithParsedData(FileCopyData data, IConnection connection)
    {
        FileSystemResult result = connection.FileSystem.CopyFile(data.SourcePath, data.DestinationPath);

        return result is FileSystemResult.Success
            ? new CommandResult.Success()
            : new CommandResult.Failure();
    }
}