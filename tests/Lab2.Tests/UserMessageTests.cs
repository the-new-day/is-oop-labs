using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Results;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class UserMessageTests
{
    [Fact]
    public void ReceiveMessage_FirstTime_StoredAsUnread()
    {
        // Arrange
        var user = new User();
        var message = new Message("Header", "Body", MessageImportanceLevel.Normal);

        // Act
        user.ReceiveMessage(message);

        // Assert
        Assert.Equal(MessageReadStatus.Unread, user.FindMessageReadStatus(message));
    }

    [Fact]
    public void TryMarkMessageAsRead_MessageIsUnread_StoresAsReadAndReturnsSuccess()
    {
        // Arrange
        var user = new User();
        var message = new Message("Header", "Body", MessageImportanceLevel.Normal);
        user.ReceiveMessage(message);

        // Act
        user.TryMarkMessageAsRead(message);

        // Assert
        Assert.Equal(MessageReadStatus.Read, user.FindMessageReadStatus(message));
    }

    [Fact]
    public void TryMarkMessageAsRead_MessageIsRead_ReturnsMessageIsAlreadyRead()
    {
        // Arrange
        var user = new User();
        var message = new Message("Header", "Body", MessageImportanceLevel.Normal);
        user.ReceiveMessage(message);
        user.TryMarkMessageAsRead(message);

        // Act
        UserTryMarkMessageAsReadResult result = user.TryMarkMessageAsRead(message);

        // Assert
        Assert.IsType<UserTryMarkMessageAsReadResult.MessageIsAlreadyRead>(result);
    }
}
