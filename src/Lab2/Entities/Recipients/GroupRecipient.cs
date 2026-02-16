using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Recipients;

public class GroupRecipient : IRecipient
{
    private readonly IReadOnlyCollection<IRecipient> _recipients;

    public GroupRecipient(IReadOnlyCollection<IRecipient> recipients)
    {
        _recipients = recipients;
    }

    public void ReceiveMessage(Message message)
    {
        foreach (IRecipient recipient in _recipients)
            recipient.ReceiveMessage(message);
    }
}
