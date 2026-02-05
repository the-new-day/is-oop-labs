using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing;

public abstract class ParserHandler
{
    private ParserHandler? _next;

    public ParserHandler SetNext(ParserHandler next)
    {
        _next = next;
        return next;
    }

    public ICommand? Parse(CommandTokens args)
    {
        ICommand? command = TryParse(args);
        if (command != null)
        {
            return command;
        }

        return _next?.Parse(args);
    }

    protected abstract ICommand? TryParse(CommandTokens args);
}
