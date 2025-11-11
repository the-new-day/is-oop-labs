using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Formatters;

public class ConsoleMessageFormatter : IMessageFormatter
{
    public void WriteHeader(string header)
    {
        Console.WriteLine($"# {header}");
    }

    public void WriteBody(string body)
    {
        Console.WriteLine($"{body}");
    }
}
