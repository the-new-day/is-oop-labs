using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Concrete;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Parsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Tests.Stubs;
using System.Collections.ObjectModel;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class CommandParserTests
{
    private readonly ParserHandler _chain;

    public CommandParserTests()
    {
        var connection = new StubConnection();
        var displayer = new StubTreeListDisplayer();

        Dictionary<string, IFileContentDisplayer> supportedFileDisplayModes = new()
        {
            { "console", new StubFileContentDisplayer() },
        };

        ParserHandler fileChain = new CommandNodeParser("copy", new FileCopyParser())
            .AddNext(new CommandNodeParser("delete", new FileDeleteParser()))
            .AddNext(new CommandNodeParser("move", new FileMoveParser()))
            .AddNext(new CommandNodeParser("rename", new FileRenameParser()))
            .AddNext(new CommandNodeParser("show", new FileShowParser(supportedFileDisplayModes)));

        ParserHandler treeChain = new CommandNodeParser("goto", new TreeGotoParser(connection))
            .AddNext(new CommandNodeParser("list", new TreeListParser(displayer)));

        _chain = new CommandNodeParser("disconnect", new DisconnectParser())
            .AddNext(new CommandNodeParser("file", fileChain))
            .AddNext(new CommandNodeParser("tree", treeChain));
    }

    [Fact]
    public void TreeGotoCommand_ShouldBeCreated_WithCorrectPath()
    {
        // Arrange
        CommandTokens tokens = CreateTokens("tree", "goto", "src/projects");

        // Act
        CommandParsingResult result = _chain.TryParse(tokens);

        // Assert
        CommandParsingResult.CommandCreated success = Assert.IsType<CommandParsingResult.CommandCreated>(result);
        TreeGotoCommand command = Assert.IsType<TreeGotoCommand>(success.Command);
        Assert.Equal("src/projects", command.Path.Path.Value);
    }

    [Fact]
    public void FileDeleteCommand_ShouldBeCreated_WithCorrectPath()
    {
        // Arrange
        CommandTokens tokens = CreateTokens("file", "delete", "data.txt");

        // Act
        CommandParsingResult result = _chain.TryParse(tokens);

        // Assert
        CommandParsingResult.CommandCreated success = Assert.IsType<CommandParsingResult.CommandCreated>(result);
        FileDeleteCommand command = Assert.IsType<FileDeleteCommand>(success.Command);
        Assert.Equal("data.txt", command.Path.Name);
    }

    [Fact]
    public void FileCopyCommand_ShouldBeCreated_WithCorrectArguments()
    {
        // Arrange
        CommandTokens tokens = CreateTokens("file", "copy", "source.log", "dest/folder");

        // Act
        CommandParsingResult result = _chain.TryParse(tokens);

        // Assert
        CommandParsingResult.CommandCreated success = Assert.IsType<CommandParsingResult.CommandCreated>(result);
        FileCopyCommand command = Assert.IsType<FileCopyCommand>(success.Command);
        Assert.Equal("source.log", command.SourcePath.Path.Value);
        Assert.Equal("dest/folder", command.DestinationPath.Path.Value);
    }

    [Fact]
    public void UnknownCommand_ShouldReturnFailure()
    {
        // Arrange
        CommandTokens tokens = CreateTokens("command", "that", "does", "not", "exist");

        // Act
        CommandParsingResult result = _chain.TryParse(tokens);

        // Assert
        Assert.IsType<CommandParsingResult.Failure>(result);
    }

    [Fact]
    public void FileShowCommand_ShouldHaveCorrectMode_WhenFlagProvided()
    {
        // Arrange
        var flags = new Dictionary<string, string> { { "m", "console" } };
        CommandTokens tokens = CreateTokensWithFlags(flags, "file", "show", "data.txt");

        // Act
        CommandParsingResult result = _chain.TryParse(tokens);

        // Assert
        CommandParsingResult.CommandCreated success = Assert.IsType<CommandParsingResult.CommandCreated>(result);
        FileShowCommand command = Assert.IsType<FileShowCommand>(success.Command);

        Assert.IsType<StubFileContentDisplayer>(command.ContentDisplayer, exactMatch: false);
    }

    private CommandTokens CreateTokens(params string[] args)
    {
        return new CommandTokens(
            new ReadOnlyCollection<string>(new List<string>(args)),
            new ReadOnlyDictionary<string, string>(new Dictionary<string, string>()));
    }

    private CommandTokens CreateTokensWithFlags(Dictionary<string, string> flags, params string[] args)
    {
        return new CommandTokens(
            new ReadOnlyCollection<string>(new List<string>(args)),
            new ReadOnlyDictionary<string, string>(flags));
    }
}
