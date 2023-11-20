using System.Net.Mime;
using N73.Notifications.Application.Common.Models.Querying;
using N73.Notifications.Application.Common.Notifications.Models;
using N73.Notifications.Domin.Common.Exceptions;
using N73.Notifications.Domin.Entities;

namespace N73.Notifications.Application.Common.Notifications.Services;

public interface INotificationAggregatorService
{
    ValueTask<FuncResult<bool>> SendAsync(
        NotificationRequest notificationRequest,
        CancellationToken cancellationToken = default);

    ValueTask<IList<NotificationTemplate>> GetTemplatesByFilterAsync(
        NotificationTemplateFilter filter,
        CancellationToken cancellationToken = default);
}