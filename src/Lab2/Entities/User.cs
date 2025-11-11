using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class User : IUser
{
    private readonly Dictionary<Message, MessageReadStatus> _receivedMessages = new();

    public void RecieveMessage(Message message)
    {
        _receivedMessages[message] = MessageReadStatus.Unread;
    }

    public UserMarkMessageAsReadResult MarkMessageAsRead(Message message)
    {
        if (!_receivedMessages.ContainsKey(message))
            return new UserMarkMessageAsReadResult.MessageHasNotBeenRecieved();

        if (_receivedMessages[message] == MessageReadStatus.Read)
            return new UserMarkMessageAsReadResult.MessageIsAlreadyRead();

        _receivedMessages[message] = MessageReadStatus.Read;
        return new UserMarkMessageAsReadResult.Success();
    }
}
