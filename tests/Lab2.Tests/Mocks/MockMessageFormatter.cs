using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Mocks;

public class MockMessageFormatter : IMessageFormatter
{
    private readonly List<string> _messageHeaders = new();

    private readonly List<string> _messageBodies = new();

    public ReadOnlyCollection<string> MessageHeaders => _messageHeaders.AsReadOnly();

    public ReadOnlyCollection<string> MessageBodies => _messageBodies.AsReadOnly();

    public void WriteHeader(string header)
    {
        _messageHeaders.Add(header);
    }

    public void WriteBody(string body)
    {
        _messageBodies.Add(body);
    }
}
