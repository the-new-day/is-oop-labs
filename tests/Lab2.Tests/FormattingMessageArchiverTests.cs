using Itmo.ObjectOrientedProgramming.Lab2.Entities.Archivers;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Tests.Mocks;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class FormattingMessageArchiverTests
{
    [Fact]
    public void Save_NormalMessage_IsSaved()
    {
        // Arrange
        var mockMessageWriter = new MockMessageWriter();
        var mockMessageFormatter = new MockMessageFormatter();
        var formattingArchiver = new FormattingMessageArchiver(mockMessageFormatter);
        var message = new Message("Header", "Body", MessageImportanceLevel.Low);

        // Act
        formattingArchiver.Save(message);

        // Assert
        Assert.Equal(["Header"], mockMessageFormatter.MessageHeaders);
        Assert.Equal(["Body"], mockMessageFormatter.MessageBodies);
    }
}
