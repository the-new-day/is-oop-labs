using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

public interface IMessageArchiver
{
    void Save(Message message);
}
