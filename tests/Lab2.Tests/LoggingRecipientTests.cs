using Itmo.ObjectOrientedProgramming.Lab2.Entities.Recipients;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Tests.Mocks;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class LoggingRecipientTests
{
    [Fact]
    public void ReceiveMessage_AnyMessage_IsLogged()
    {
        // Arrange
        var mockMessageLogger = new MockMessageLogger();
        var mockRecipient = new MockRecipient();
        var loggingRecipient = new LoggingRecipient(mockRecipient, mockMessageLogger);
        var message = new Message("Header", "Body", MessageImportanceLevel.Low);

        // Act
        loggingRecipient.ReceiveMessage(message);

        // Assert
        Assert.True(mockMessageLogger.HasLoggedMessage(message));
    }
}
