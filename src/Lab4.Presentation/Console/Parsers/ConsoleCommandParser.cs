using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Console.Parsers.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Console.Parsers.Tokenizers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Console.Parsers;

public class ConsoleCommandParser : ICommandParser
{
    private readonly CommandTokenizer _tokenizer = new();
    private readonly Dictionary<int, HashSet<string>> _commandsByWordCount;

    public ConsoleCommandParser(IEnumerable<string> availableCommands)
    {
        _commandsByWordCount = new Dictionary<int, HashSet<string>>();

        foreach (string command in availableCommands)
        {
            string normalized = command.Trim().ToLowerInvariant();
            int wordCount = normalized.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;

            if (!_commandsByWordCount.TryGetValue(wordCount, out HashSet<string>? value))
            {
                value = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                _commandsByWordCount[wordCount] = value;
            }

            value.Add(normalized);
        }
    }

    public CommandParsingResult Parse(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return new CommandParsingResult.EmptyCommand();

        var tokens = _tokenizer.Tokenize(input.Trim()).ToList();

        if (tokens.Count == 0)
            return new CommandParsingResult.NoTokensFound();

        (string? commandName, int consumedTokens) = FindCommandName(tokens);
        if (commandName is null)
            return new CommandParsingResult.UnknownCommand(tokens[0]);

        (Dictionary<int, string> parameters, Dictionary<string, string> flags)
            = ParseArguments(tokens.Skip(consumedTokens));

        var parsedCommand = new ParsedCommand(commandName, parameters, flags);
        return new CommandParsingResult.Success(parsedCommand);
    }

    private (string? CommandName, int ConsumedTokens) FindCommandName(List<string> tokens)
    {
        for (int wordCount = GetMaxCommandWords(); wordCount >= 1; wordCount--)
        {
            if (tokens.Count >= wordCount)
            {
                string potentialCommand = string.Join(" ", tokens.Take(wordCount)).ToLowerInvariant();

                if (_commandsByWordCount.TryGetValue(wordCount, out HashSet<string>? commands) &&
                    commands.Contains(potentialCommand))
                {
                    return (potentialCommand, wordCount);
                }
            }
        }

        return (null, 1);
    }

    private int GetMaxCommandWords()
    {
        return _commandsByWordCount.Keys.Count != 0 ? _commandsByWordCount.Keys.Max() : 0;
    }

    private (Dictionary<int, string> Parameters, Dictionary<string, string> Flags)
        ParseArguments(IEnumerable<string> args)
    {
        var parameters = new Dictionary<int, string>();
        var flags = new Dictionary<string, string>();

        var argsList = args.ToList();
        int paramIndex = 0;

        for (int i = 0; i < argsList.Count; i++)
        {
            string arg = argsList[i];

            if (IsFlag(arg))
            {
                string flagName = arg.TrimStart('-');
                string? flagValue = null;

                if (i + 1 < argsList.Count && !IsFlag(argsList[i + 1]))
                {
                    flagValue = argsList[i + 1];
                    i++;
                }

                flags[flagName] = flagValue ?? string.Empty;
            }
            else
            {
                parameters[paramIndex] = arg;
                paramIndex++;
            }
        }

        return (parameters, flags);
    }

    private bool IsFlag(string token)
    {
        return token.StartsWith('-') && token.Length > 1;
    }
}
