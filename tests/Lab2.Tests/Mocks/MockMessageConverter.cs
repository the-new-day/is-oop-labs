using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Mocks;

public class MockMessageConverter : IMessageConverter
{
    private readonly List<string> _messageHeaders = new();

    private readonly List<string> _messageBodies = new();

    public ReadOnlyCollection<string> MessageHeaders => _messageHeaders.AsReadOnly();

    public ReadOnlyCollection<string> MessageBodies => _messageBodies.AsReadOnly();

    public string ConvertHeader(string header)
    {
        _messageHeaders.Add(header);
        return header;
    }

    public string ConvertBody(string body)
    {
        _messageBodies.Add(body);
        return body;
    }
}
