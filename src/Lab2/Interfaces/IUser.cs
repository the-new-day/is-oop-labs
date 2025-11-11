using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

public interface IUser
{
    void RecieveMessage(Message message);

    UserMarkMessageAsReadResult MarkMessageAsRead(Message message);
}
