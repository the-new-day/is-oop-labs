using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Formatters;

public class FileMessageFormatter : IMessageFormatter
{
    private readonly string _filePath;

    public FileMessageFormatter(string filePath)
    {
        _filePath = filePath;
    }

    public void WriteHeader(string header)
    {
        File.AppendAllText(_filePath, $"# {header}\n");
    }

    public void WriteBody(string body)
    {
        File.AppendAllText(_filePath, $"{body}\n");
    }
}
