namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

public interface IMessageFormatter
{
    void WriteHeader(string header);

    void WriteBody(string body);
}