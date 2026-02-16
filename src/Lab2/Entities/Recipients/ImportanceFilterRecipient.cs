using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Recipients;

public class ImportanceFilterRecipient : IRecipient
{
    private readonly IRecipient _recipient;

    private readonly MessageImportanceLevel _minImportanceLevel;

    public ImportanceFilterRecipient(IRecipient recipient, MessageImportanceLevel minImportanceLevel)
    {
        _recipient = recipient;
        _minImportanceLevel = minImportanceLevel;
    }

    public void ReceiveMessage(Message message)
    {
        if (message.ImportanceLevel >= _minImportanceLevel)
            _recipient.ReceiveMessage(message);
    }
}
