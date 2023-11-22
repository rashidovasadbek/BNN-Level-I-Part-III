using N73.Notifications.Application.Common.Models.Quering;
using N73.Notifications.Application.Common.Notifications.Models;
using N73.Notifications.Domin.Entities;
using N73.Notifications.Domin.Enums;

namespace N73.Notifications.Application.Common.Notifications.Services;

public interface IEmailTemplateService
{
    ValueTask<IList<EmailTemplate>> GetByFilterAsync(
        FilterPagination paginationOptions,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ValueTask<EmailTemplate?> GetByTypeAsync(
        NotificationTemplateType templateType,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ValueTask<EmailTemplate> CreateAsync(
        EmailTemplate emailTemplate,
        bool saveChange = true,
        CancellationToken cancellationToken = default);
}