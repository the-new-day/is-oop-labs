using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Connection;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Connection.State;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Rendering;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation;

public class Program
{
    public static void Main()
    {
        string defaultConnectionMode = "local";

        Dictionary<string, IConnectionFactory> supportedConnectionModes = new();

        var localFactory = new LocalConnectionFactory(
                new DisconnectedState(supportedConnectionModes.Keys.ToHashSet(), defaultConnectionMode));

        supportedConnectionModes.Add("local", localFactory);

        Dictionary<string, IFileContentDisplayer> supportedFileShowModes = new()
        {
            { "console", new FileContentDisplayer(new ConsoleOutputRenderer()) },
        };

        var tokenizer = new Tokenizer();
        var cli = new Cli(
            tokenizer,
            supportedFileShowModes,
            supportedConnectionModes,
            defaultConnectionMode);

        try
        {
            cli.Start();
        }
        catch (Exception e)
        {
            cli.PrintError(e.Message);
        }
    }
}
