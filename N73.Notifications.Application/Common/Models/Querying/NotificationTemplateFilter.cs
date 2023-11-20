using N73.Notifications.Application.Common.Models.Quering;
using N73.Notifications.Domin.Enums;

namespace N73.Notifications.Application.Common.Models.Querying;

public class NotificationTemplateFilter : FilterPagination
{
    public IList<NotificationType> TemplateType { get; set; }
}