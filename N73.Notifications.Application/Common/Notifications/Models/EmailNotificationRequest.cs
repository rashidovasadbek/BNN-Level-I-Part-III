using N73.Notifications.Domin.Enums;

namespace N73.Notifications.Application.Common.Notifications.Models;

public class EmailNotificationRequest : NotificationRequest
{
    public EmailNotificationRequest() => Type = NotificationType.Email;

}