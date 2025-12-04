using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete.Data;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.State.Connection;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete;

public class TreeGotoCommand : CommandBase<TreeGotoData>
{
    public TreeGotoCommand(ICommandDataParser<TreeGotoData> dataParser)
        : base(dataParser)
    {
    }

    protected override CommandResult ExecuteWithParsedData(TreeGotoData data, IConnection connection)
    {
        connection.FileSystem.SetRoot(data.Path);
        return new CommandResult.Success();
    }
}
