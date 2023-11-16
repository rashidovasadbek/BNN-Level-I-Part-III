using N73.Notifications.Domin.Common.Entities;
using N73.Notifications.Domin.Enums;

namespace N73.Notifications.Domin.Entities;

public class UserSettings : IEntity
{
    public Guid Id { get; set; }
    
    public NotificationType? PreferredNotificationType { get; set; }
}