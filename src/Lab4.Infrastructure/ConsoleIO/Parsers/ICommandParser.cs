using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Infrastructure.ConsoleIO.Parsers;

public interface ICommandParser
{
    CommandParsingResult Parse(string input);
}
