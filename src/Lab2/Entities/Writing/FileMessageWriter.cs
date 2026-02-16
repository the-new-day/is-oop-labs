using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Writing;

public class FileMessageWriter : IMessageWriter
{
    private readonly string _filePath;

    public FileMessageWriter(string filePath)
    {
        _filePath = filePath;
    }

    public void Write(string message)
    {
        File.AppendAllText(_filePath, message);
    }
}
