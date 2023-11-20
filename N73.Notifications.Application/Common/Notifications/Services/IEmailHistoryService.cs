using N73.Notifications.Application.Common.Models.Quering;
using N73.Notifications.Domin.Entities;

namespace N73.Notifications.Application.Common.Notifications.Services;

public interface IEmailHistoryService
{
    ValueTask<IList<EmailHistory>> GetByFilterAsync(
        FilterPagination filterPagination,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ValueTask<EmailHistory> CreateAsync(
        EmailHistory smsTemplate,
        bool saveChange = true,
        CancellationToken cancellationToken = default);
}