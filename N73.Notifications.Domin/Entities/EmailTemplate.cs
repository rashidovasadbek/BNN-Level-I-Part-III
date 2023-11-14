using N73.Notifications.Domin.Enums;
using Type = N73.Notifications.Domin.Enums.NotificationType;

namespace N73.Notifications.Domin.Entities;

public class EmailTemplate : NotificationTemplate
{
    public EmailTemplate()
    {
        Type = Type.Email;
    }

    public string Subject { get; set; } = default!;
}