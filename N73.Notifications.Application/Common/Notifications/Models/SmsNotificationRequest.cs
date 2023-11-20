using N73.Notifications.Domin.Enums;

namespace N73.Notifications.Application.Common.Notifications.Models;

public class SmsNotificationRequest : NotificationRequest
{
    public SmsNotificationRequest() => Type = NotificationType.Sms;
}