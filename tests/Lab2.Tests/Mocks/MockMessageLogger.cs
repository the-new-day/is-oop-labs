using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Mocks;

public class MockMessageLogger : IMessageLogger
{
    private readonly List<Message> _loggedMessages = new();

    public int LogMessageCallCount { get; private set; }

    public void LogMessage(Message message)
    {
        _loggedMessages.Add(message);
        LogMessageCallCount++;
    }

    public bool HasLoggedMessage(Message message)
    {
        return _loggedMessages.Contains(message);
    }
}
