using N73.Notifications.Domin.Common.Entities;
using N73.Notifications.Domin.Enums;

namespace N73.Notifications.Domin.Entities;

public class NotificationHistory : IEntity
{
    public Guid Id { get; set; }
    
    public Guid TemplateId { get; set; }
    
    public Guid SenderUserId { get; set; }
    
    public Guid ReceiverUserId { get; set; }
    
    public NotificationType Type { get; set; }

    public string Content { get; set; } = default!;
    
    public NotificationTemplate Template { get; set; }
}