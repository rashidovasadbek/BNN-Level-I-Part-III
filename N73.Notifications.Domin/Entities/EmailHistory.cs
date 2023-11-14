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
}