using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Mocks;

public class MockRecipient : IRecipient
{
    private readonly List<Message> _receivedMessages = new();

    private readonly Dictionary<Message, int> _receiveCount = new();

    public int ReceiveCallCount { get; private set; }

    public int GetReceiveCount(Message message)
        => _receiveCount.TryGetValue(message, out int count) ? count : 0;

    public void ReceiveMessage(Message message)
    {
        _receivedMessages.Add(message);
        _receiveCount[message] = GetReceiveCount(message) + 1;
        ReceiveCallCount++;
    }

    public bool HasReceivedMessage(Message message)
    {
        return _receivedMessages.Contains(message);
    }
}
