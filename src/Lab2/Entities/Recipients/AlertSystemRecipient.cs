using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Recipients;

public class AlertSystemRecipient : IRecipient
{
    private readonly IRecipient _recipient;

    private readonly IAlertSystem _alertSystem;

    private readonly HashSet<string> _suspiciousWords;

    public AlertSystemRecipient(IRecipient recipient, IAlertSystem alertSystem, IEnumerable<string> suspiciousWords)
    {
        _recipient = recipient;
        _alertSystem = alertSystem;
        _suspiciousWords = new HashSet<string>(suspiciousWords, StringComparer.OrdinalIgnoreCase);
    }

    public void ReceiveMessage(Message message)
    {
        if (HasSuspiciousWords(message))
            _alertSystem.Alert();

        _recipient.ReceiveMessage(message);
    }

    private bool HasSuspiciousWords(Message message)
    {
        string[] headerWords = message.Header.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string[] bodyWords = message.Body.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        return headerWords.Any(_suspiciousWords.Contains) || bodyWords.Any(_suspiciousWords.Contains);
    }
}
