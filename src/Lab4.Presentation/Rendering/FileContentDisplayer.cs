using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Rendering;

public class FileContentDisplayer : IFileContentDisplayer
{
    private readonly IOutputRenderer _renderer;

    public FileContentDisplayer(IOutputRenderer outputRenderer)
    {
        _renderer = outputRenderer;
    }

    public void Display(Stream fileStream)
    {
        using var reader = new StreamReader(fileStream);
        string? line;

        while ((line = reader.ReadLine()) != null)
        {
            _renderer.RenderLine(line);
        }
    }
}
