using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Console.Parsers;

public interface ICommandParser
{
    CommandParsingResult Parse(string input);
}
