using Itmo.ObjectOrientedProgramming.Lab2.Entities.Recipients;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Tests.Mocks;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class ImportanceFilterTests
{
    [Fact]
    public void ReceiveMessage_MessageBelowImportance_NotDelivered()
    {
        // Arrange
        var mockRecipient = new MockRecipient();
        var recipientImportanceFilter = new ImportanceFilterRecipient(mockRecipient, MessageImportanceLevel.High);
        var message = new Message("Header", "Body", MessageImportanceLevel.Low);

        // Act
        recipientImportanceFilter.ReceiveMessage(message);

        // Assert
        Assert.False(mockRecipient.HasReceivedMessage(message));
        Assert.Equal(0, mockRecipient.ReceiveCallCount);
    }

    [Fact]
    public void ReceiveMessage_OneUserWithAndWithoutImportanceFilter_NotDeliveredAndDelivered()
    {
        // Arrange
        var userMock = new CountingUserMock();
        var userRecipient = new UserRecipient(userMock);
        var userImportanceFilter = new ImportanceFilterRecipient(userRecipient, MessageImportanceLevel.High);
        var groupRecipient = new GroupRecipient([userRecipient, userImportanceFilter]);
        var message = new Message("Header", "Body", MessageImportanceLevel.Low);

        // Act
        groupRecipient.ReceiveMessage(message);

        // Assert
        Assert.Equal(1, userMock.GetReceiveCount(message));
    }
}
