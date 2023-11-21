using N73.Notifications.Domin.Enums;

namespace N73.Notifications.Application.Common.Notifications.Models;

public class NotificationRequest
{
    public Guid? SenderUserId { get; set; }
    
    public Guid ReceiverUserId { get; set; }
    
    public NotificationTemplateType TemplateType { get; set; }
    
    public NotificationType? Type { get; set; }
    
    public Dictionary<string, string>? Variables { get; set; }
}