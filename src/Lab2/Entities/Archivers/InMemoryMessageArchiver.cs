using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Archivers;

public class InMemoryMessageArchiver : IMessageArchiver
{
    private readonly List<Message> _messages = new();

    public ReadOnlyCollection<Message> Messages => _messages.AsReadOnly();

    public void Save(Message message)
    {
        _messages.Add(message);
    }
}
