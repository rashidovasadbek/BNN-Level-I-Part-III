using System.Net.Mime;
using N73.Notifications.Application.Common.Models.Quering;
using N73.Notifications.Domin.Entities;
using N73.Notifications.Domin.Enums;

namespace N73.Notifications.Application.Common.Notifications.Services;

public interface ISmsTemplateService
{
    ValueTask<IList<SmsTemplate>> GetByFilterAsync(
        FilterPagination filterPagination,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ValueTask<SmsTemplate?> GetByTypeAsync(
        NotificationTemplateType templateType,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ValueTask<SmsTemplate> CreateAsync(
        SmsTemplate smsTemplate,
        bool saveChange = false,
        CancellationToken cancellationToken = default);
}