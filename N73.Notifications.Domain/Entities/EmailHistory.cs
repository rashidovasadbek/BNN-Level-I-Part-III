using System.ComponentModel.DataAnnotations.Schema;
using  N73.Notifications.Domin.Enums;

namespace N73.Notifications.Domin.Entities;

public class EmailHistory : NotificationHistory
{
    public EmailHistory()
    {
        Type = NotificationType.Email;
    }

    public string SenderEmailAddress { get; set; } = default!;

    public string ReceiverEmailAddress { get; set; } = default!;

    public string Subject { get; set; } = default!;

    [NotMapped]
    public EmailTemplate EmailTemplate
    {
        get => Template is null ? Template as EmailTemplate : null;
        set => Template = value;
    }
}