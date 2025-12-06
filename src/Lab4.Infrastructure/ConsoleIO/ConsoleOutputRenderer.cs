using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Renderering;

namespace Itmo.ObjectOrientedProgramming.Lab4.Infrastructure.ConsoleIO;

public class ConsoleOutputRenderer : IOutputRenderer
{
    public void Render(string text)
    {
        Console.Write(text);
    }

    public void RenderLine(string text)
    {
        Console.WriteLine(text);
    }
}
