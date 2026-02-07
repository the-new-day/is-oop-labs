using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParsing.Results;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class TokenizerTests
{
    [Fact]
    public void Tokenize_ShouldReturnArguments_WhenNoFlagsProvided()
    {
        // Arrange
        var tokenizer = new Tokenizer();
        string input = "tree goto /home/user";

        // Act
        TokenizingResult result = tokenizer.Tokenize(input);

        // Assert
        TokenizingResult.Success success = Assert.IsType<TokenizingResult.Success>(result);
        Assert.Equal(3, success.Tokens.Arguments.Count);
        Assert.Equal("tree", success.Tokens.Arguments[0]);
        Assert.Equal("goto", success.Tokens.Arguments[1]);
        Assert.Equal("/home/user", success.Tokens.Arguments[2]);
        Assert.Empty(success.Tokens.Flags);
    }

    [Fact]
    public void Tokenize_ShouldReturnFlagsAndArguments_WhenBothAreProvided()
    {
        // Arrange
        var tokenizer = new Tokenizer();
        string input = "tree list -d 2 -m local";

        // Act
        TokenizingResult result = tokenizer.Tokenize(input);

        // Assert
        TokenizingResult.Success success = Assert.IsType<TokenizingResult.Success>(result);
        Assert.Equal(2, success.Tokens.Arguments.Count);
        Assert.Equal("2", success.Tokens.Flags["d"]);
        Assert.Equal("local", success.Tokens.Flags["m"]);
    }

    [Fact]
    public void Tokenize_ShouldHandleMultipleSpaces_WhenInputIsMessy()
    {
        // Arrange
        var tokenizer = new Tokenizer();
        string input = "  file  copy   path1  path2  ";

        // Act
        TokenizingResult result = tokenizer.Tokenize(input);

        // Assert
        TokenizingResult.Success success = Assert.IsType<TokenizingResult.Success>(result);
        Assert.Contains("file", success.Tokens.Arguments);
        Assert.Contains("copy", success.Tokens.Arguments);
    }

    [Fact]
    public void Tokenize_ShouldReturnFailure_WhenFlagHasNoValue()
    {
        // Arrange
        var tokenizer = new Tokenizer();
        string input = "tree list -d";

        // Act
        TokenizingResult result = tokenizer.Tokenize(input);

        // Assert
        Assert.IsType<TokenizingResult.Failure>(result);
    }

    [Fact]
    public void Tokenize_ShouldCorrectyMapFlags_WhenInterleavedWithArguments()
    {
        // Arrange
        var tokenizer = new Tokenizer();
        string input = "command -f val1 arg1 -g val2 arg2";

        // Act
        TokenizingResult result = tokenizer.Tokenize(input);

        // Assert
        TokenizingResult.Success success = Assert.IsType<TokenizingResult.Success>(result);
        Assert.Equal(3, success.Tokens.Arguments.Count);
        Assert.Equal("val1", success.Tokens.Flags["f"]);
        Assert.Equal("val2", success.Tokens.Flags["g"]);
    }
}
