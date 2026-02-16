using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.AlertSystem;

public class SoundAlertSystem : IAlertSystem
{
    public void Alert()
    {
        Console.Beep();
    }
}
