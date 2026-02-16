namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

public interface IMessageConverter
{
    string ConvertHeader(string header);

    string ConvertBody(string body);
}
