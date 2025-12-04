using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Console.Parsers.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Results;

public abstract record CommandParsingResult
{
    private CommandParsingResult() { }

    public sealed record Success(ParsedCommand ParsedCommand) : CommandParsingResult;

    public sealed record UnknownCommand(string CommandName) : CommandParsingResult;

    public sealed record EmptyCommand : CommandParsingResult;

    public sealed record NoTokensFound : CommandParsingResult;
}
