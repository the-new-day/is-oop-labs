using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.State.Connection;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete;

public abstract class CommandBase<TData> : ICommand
{
    private readonly ICommandDataParser<TData> _dataParser;

    protected CommandBase(ICommandDataParser<TData> dataParser)
    {
        _dataParser = dataParser;
    }

    public CommandResult Execute(CommandData commandData, IConnection connection)
    {
        CommandDataParsingResult<TData> parsedData = _dataParser.Parse(commandData);
        if (parsedData is CommandDataParsingResult<TData>.Failure error)
        {
            return new CommandResult.Failure();
        }

        if (parsedData is CommandDataParsingResult<TData>.Success success)
        {
            return ExecuteWithParsedData(success.Data, connection);
        }

        throw new InvalidOperationException();
    }

    protected abstract CommandResult ExecuteWithParsedData(TData data, IConnection connection);
}
