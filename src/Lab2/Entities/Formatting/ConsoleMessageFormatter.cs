using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Formatting;

public class ConsoleMessageFormatter : IMessageFormatter
{
    private readonly IMessageConverter _converter;

    public ConsoleMessageFormatter(IMessageConverter converter)
    {
        _converter = converter;
    }

    public void WriteHeader(string header)
    {
        Console.Write(_converter.ConvertHeader(header));
    }

    public void WriteBody(string body)
    {
        Console.Write(_converter.ConvertBody(body));
    }
}
