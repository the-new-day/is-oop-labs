using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Topic
{
    public string Name { get; }

    private readonly IReadOnlyCollection<IRecipient> _recipients;

    public Topic(string name, IReadOnlyCollection<IRecipient> recipients)
    {
        Name = name;
        _recipients = recipients;
    }

    public void ReceiveMessage(Message message)
    {
        foreach (IRecipient recipient in _recipients)
            recipient.ReceiveMessage(message);
    }
}
