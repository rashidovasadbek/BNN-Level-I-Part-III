using N73.Notifications.Domin.Common.Entities;
using N73.Notifications.Domin.Enums;

namespace N73.Notifications.Domin.Entities;

public abstract class NotificationTemplate : IEntity
{
    public Guid Id { get; set; }
    
    public string Content { get; set; } = default!;
    
    public NotificationType Type { get; set; }

    public NotificationTemplateType TemplateType { get; set; }
    
    public IList<NotificationHistory> Histories { get; set; } = new List<NotificationHistory>();
}