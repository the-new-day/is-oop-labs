using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class User : IUser
{
    private readonly Dictionary<Message, MessageReadStatus> _receivedMessagesStatus = new();

    public void ReceiveMessage(Message message)
    {
        _receivedMessagesStatus[message] = MessageReadStatus.Unread;
    }

    public UserTryMarkMessageAsReadResult TryMarkMessageAsRead(Message message)
    {
        if (!_receivedMessagesStatus.ContainsKey(message))
            return new UserTryMarkMessageAsReadResult.MessageHasNotBeenReceived();

        if (_receivedMessagesStatus[message] == MessageReadStatus.Read)
            return new UserTryMarkMessageAsReadResult.MessageIsAlreadyRead();

        _receivedMessagesStatus[message] = MessageReadStatus.Read;
        return new UserTryMarkMessageAsReadResult.Success();
    }

    public MessageReadStatus? FindMessageReadStatus(Message message)
    {
        return _receivedMessagesStatus.TryGetValue(message, out MessageReadStatus status)
            ? status
            : null;
    }
}
