using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.State;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Connection;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Rendering;
using Directory = Itmo.ObjectOrientedProgramming.Lab4.Core.Nodes.Directory;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation;

public class Cli
{
    private readonly Tokenizer _tokenizer;

    private readonly Dictionary<string, IFileContentDisplayer> _supportedFileShowModes;

    private readonly Dictionary<string, IConnectionFactory> _supportedConnectionModes;

    private readonly string _defaultConnectionMode;

    private readonly ConnectionManager _connectionManager = new();

    private IConnectionState _connectionState;

    public Cli(
        Tokenizer tokenizer,
        Dictionary<string, IFileContentDisplayer> supportedFileShowModes,
        Dictionary<string, IConnectionFactory> supportedConnectionModes,
        string defaultConnectionMode)
    {
        _tokenizer = tokenizer;
        _supportedFileShowModes = supportedFileShowModes;
        _supportedConnectionModes = supportedConnectionModes;
        _defaultConnectionMode = defaultConnectionMode;

        _connectionState = new DisconnectedState(
            supportedConnectionModes.Keys.ToHashSet(),
            defaultConnectionMode);
    }

    public void PrintError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Error: {message}");
        Console.ResetColor();
    }

    public void Start()
    {
        while (true)
        {
            Console.Write("> ");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input)) continue;

            TokenizingResult result = _tokenizer.Tokenize(input);

            switch (result)
            {
                case TokenizingResult.Success success:
                    Parse(success.Tokens);
                    break;
                case TokenizingResult.Failure failure:
                    PrintError(failure.Message);
                    break;
            }
        }
    }

    private void Parse(CommandTokens tokens)
    {
        ParserHandler parserHandler = _connectionState.GetParserHandler();
        CommandParsingResult result = parserHandler.TryParse(tokens);

        if (result is CommandParsingResult.CommandCreated success)
        {
            HandleCommandCreated(success.Command);
        }
        else if (result is CommandParsingResult.Connect connect)
        {
            HandleConnect(connect);
        }
        else if (result is CommandParsingResult.Disconnect disconnet)
        {
            HandleDisconnect();
        }
        else if (result is CommandParsingResult.Failure failure)
        {
            PrintError(failure.Message);
        }
    }

    private void HandleDisconnect()
    {
        _connectionManager.Disconnect();
        _connectionState = new DisconnectedState(_supportedConnectionModes.Keys.ToHashSet(), _defaultConnectionMode);
    }

    private void HandleConnect(CommandParsingResult.Connect connect)
    {
        if (!_supportedConnectionModes.ContainsKey(connect.Mode))
        {
            PrintError($"Unknown connect mode: {connect.Mode}");
            return;
        }

        IConnectionFactory connectionFactory = _supportedConnectionModes[connect.Mode];
        _connectionManager.Connect(new Directory(connect.Address), connectionFactory);

        Console.WriteLine(new Directory(connect.Address).Path.Value);

        if (_connectionManager.Connection is null)
        {
            throw new InvalidOperationException("Connection in ConnectionManager is null");
        }

        _connectionState = new ConnectedState(
            _connectionManager.Connection,
            new TreeListDisplayer(new NodeDisplayFormatter(), new ConsoleOutputRenderer()),
            _supportedFileShowModes);
    }

    private void HandleCommandCreated(ICommand command)
    {
        if (_connectionManager.Connection is null)
        {
            throw new InvalidOperationException("Connection in ConnectionManager is null");
        }

        CommandExecutionResult result = command.Execute(_connectionManager.Connection.FileSystem);
        if (result is CommandExecutionResult.Failure failure)
        {
            PrintError($"Command failed: {failure.Message}");
        }
    }
}
