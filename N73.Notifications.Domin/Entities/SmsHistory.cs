using N73.Notifications.Domin.Enums;

namespace N73.Notifications.Domin.Entities;

public class SmsHistory : NotificationHistory
{
    public SmsHistory()
    {
        Type = NotificationType.Sms;
    }

    public string SenderPhoneAddress { get; set; } = default!;

    public string ReceiverPhoneAddress { get; set; } = default!;
}