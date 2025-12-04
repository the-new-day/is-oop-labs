using Itmo.ObjectOrientedProgramming.Lab4.Core.State;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Console;

public class Program
{
    public static void Main()
    {
        StateManager stateManager;

        System.Console.WriteLine("File System. Waiting for you command...");

        while (true)
        {
            string? command = System.Console.ReadLine();

            if (string.IsNullOrEmpty(command))
            {
                command = "default";
            }

            System.Console.WriteLine(command);
        }
    }
}
