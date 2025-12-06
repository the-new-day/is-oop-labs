using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Renderering;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Console;

public class ConsoleOutputRenderer : IOutputRenderer
{
    public void Render(string text)
    {
        System.Console.Write(text);
    }

    public void RenderLine(string text)
    {
        System.Console.WriteLine(text);
    }
}
