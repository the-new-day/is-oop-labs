using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Formatting;

public class FileMessageFormatter : IMessageFormatter
{
    private readonly IMessageConverter _converter;

    private readonly string _filePath;

    public FileMessageFormatter(IMessageConverter converter, string filePath)
    {
        _converter = converter;
        _filePath = filePath;
    }

    public void WriteHeader(string header)
    {
        File.AppendAllText(_filePath, _converter.ConvertHeader(header));
    }

    public void WriteBody(string body)
    {
        File.AppendAllText(_filePath, _converter.ConvertBody(body));
    }
}
