using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

public interface IUser
{
    void ReceiveMessage(Message message);

    UserTryMarkMessageAsReadResult TryMarkMessageAsRead(Message message);

    MessageReadStatus? FindMessageReadStatus(Message message);
}
