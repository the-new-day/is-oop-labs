using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Recipients;

public class MessageArchiverRecipient : IRecipient
{
    private readonly IMessageArchiver _archiver;

    public MessageArchiverRecipient(IMessageArchiver archiver)
    {
        _archiver = archiver;
    }

    public void ReceiveMessage(Message message)
    {
        _archiver.Save(message);
    }
}
