using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public interface ICommandDataParser<TData>
{
    CommandDataParsingResult<TData> Parse(CommandData commandData);
}
