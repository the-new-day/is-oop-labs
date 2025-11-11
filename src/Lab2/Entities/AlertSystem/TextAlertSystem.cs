using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.AlertSystem;

public class TextAlertSystem : IAlertSystem
{
    private readonly string _text;

    public TextAlertSystem(string text)
    {
        _text = text;
    }

    public void Alert()
    {
        Console.WriteLine(_text);
    }
}
