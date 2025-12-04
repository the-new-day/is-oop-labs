using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete.Data;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.State.Connection;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete;

public class FileRenameCommand : CommandBase<FileRenameData>
{
    public FileRenameCommand(ICommandDataParser<FileRenameData> dataParser)
        : base(dataParser)
    {
    }

    protected override CommandResult ExecuteWithParsedData(FileRenameData data, IConnection connection)
    {
        FileSystemResult result = connection.FileSystem.RenameFile(data.Path, data.Name);

        return result is FileSystemResult.Success
            ? new CommandResult.Success()
            : new CommandResult.Failure();
    }
}