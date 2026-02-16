using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Archivers;

public class FormattingMessageArchiver : IMessageArchiver
{
    private readonly IMessageFormatter _formatter;

    public FormattingMessageArchiver(IMessageFormatter formatter)
    {
        _formatter = formatter;
    }

    public void Save(Message message)
    {
        _formatter.WriteHeader(message.Header);
        _formatter.WriteBody(message.Body);
    }
}
