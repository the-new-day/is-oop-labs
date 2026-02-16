using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Recipients;

public class LoggingRecipient : IRecipient
{
    private readonly IRecipient _recipient;

    private readonly IMessageLogger _logger;

    public LoggingRecipient(IRecipient recipient, IMessageLogger logger)
    {
        _recipient = recipient;
        _logger = logger;
    }

    public void ReceiveMessage(Message message)
    {
        _logger.LogMessage(message);
        _recipient.ReceiveMessage(message);
    }
}
