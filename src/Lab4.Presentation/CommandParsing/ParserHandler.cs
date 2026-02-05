using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing;

public abstract class ParserHandler
{
    private ParserHandler? _next;

    public ParserHandler AddNext(ParserHandler next)
    {
        if (_next is null)
        {
            _next = next;
        }
        else
        {
            _next.AddNext(next);
        }

        return this;
    }

    protected CommandParsingResult CallNext(CommandTokens args)
    {
        return _next?.TryParse(args)
            ?? new CommandParsingResult.Failure("Unknown command");
    }

    protected abstract CommandParsingResult TryParse(CommandTokens tokens);
}
