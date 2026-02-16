using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Mocks;

public class MockMessageWriter : IMessageWriter
{
    private readonly List<string> _writtenMessages = new();

    public void Write(string message)
    {
        _writtenMessages.Add(message);
    }
}
