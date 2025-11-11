using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Mocks;

public class CountingUserMock : IUser
{
    private readonly Dictionary<Message, int> _receiveCount = new();

    public int GetReceiveCount(Message message)
        => _receiveCount.TryGetValue(message, out int count) ? count : 0;

    public void ReceiveMessage(Message message)
    {
        _receiveCount[message] = GetReceiveCount(message) + 1;
    }

    public UserTryMarkMessageAsReadResult TryMarkMessageAsRead(Message message)
    {
        return new UserTryMarkMessageAsReadResult.Success();
    }

    public MessageReadStatus? FindMessageReadStatus(Message message)
    {
        return MessageReadStatus.Unread;
    }
}
