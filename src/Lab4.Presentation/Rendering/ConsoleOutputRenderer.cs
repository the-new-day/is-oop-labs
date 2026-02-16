namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Rendering;

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
