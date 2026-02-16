using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Convertation;

public class MarkdownMessageConverter : IMessageConverter
{
    public string ConvertHeader(string header)
    {
        return $"# {header}\n";
    }

    public string ConvertBody(string body)
    {
        return $"{body}\n";
    }
}
