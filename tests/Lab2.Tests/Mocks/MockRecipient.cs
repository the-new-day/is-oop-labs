using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Mocks;

public class MockRecipient : IRecipient
{
    private readonly List<Message> _receivedMessages = new();

    public int ReceiveCallCount { get; private set; }

    public void ReceiveMessage(Message message)
    {
        _receivedMessages.Add(message);
        ReceiveCallCount++;
    }

    public bool HasReceivedMessage(Message message)
    {
        return _receivedMessages.Contains(message);
    }
}
