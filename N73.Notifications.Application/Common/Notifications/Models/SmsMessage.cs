using N73.Notifications.Domin.Entities;

namespace N73.Notifications.Application.Common.Notifications.Models;

public class SmsMessage : NotificationMessage
{
    public string SenderPhoneNumber { get; set; } = default!;

    public string ReceiverPhoneNumber { get; set; } = default!;

    public SmsTemplate Template { get; set; } = default!;

    public string Message { get; set; } = default!;
}