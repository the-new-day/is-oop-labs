using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete.Data;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.State.Connection;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete;

public class FileDeleteCommand : CommandBase<FileDeleteData>
{
    public FileDeleteCommand(ICommandDataParser<FileDeleteData> dataParser)
        : base(dataParser)
    {
    }

    protected override CommandResult ExecuteWithParsedData(FileDeleteData data, IConnection connection)
    {
        FileSystemResult result = connection.FileSystem.DeleteFile(data.Path);

        return result is FileSystemResult.Success
            ? new CommandResult.Success()
            : new CommandResult.Failure();
    }
}