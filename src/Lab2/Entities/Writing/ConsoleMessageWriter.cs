using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Writing;

public class ConsoleMessageWriter : IMessageWriter
{
    public void Write(string message)
    {
        Console.Write(message);
    }
}
