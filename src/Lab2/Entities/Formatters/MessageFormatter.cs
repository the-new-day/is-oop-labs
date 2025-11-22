using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Formatters;

public class MessageFormatter : IMessageFormatter
{
    private readonly IMessageWriter _writer;

    private readonly IMessageConverter _converter;

    public MessageFormatter(IMessageWriter writer, IMessageConverter converter)
    {
        _writer = writer;
        _converter = converter;
    }

    public void WriteHeader(string header)
    {
        _writer.Write(_converter.ConvertHeader(header));
    }

    public void WriteBody(string body)
    {
        _writer.Write(_converter.ConvertBody(body));
    }
}
