using N73.Notifications.Domin.Enums;
using Type = N73.Notifications.Domin.Enums.NotificationType;
namespace N73.Notifications.Domin.Entities;

public class SmsTemplate : NotificationTemplate
{
    public SmsTemplate()
    {
        Type = Type.Sms;
    }
}