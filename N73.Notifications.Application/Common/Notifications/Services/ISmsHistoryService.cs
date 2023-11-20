using N73.Notifications.Application.Common.Models.Quering;
using N73.Notifications.Application.Common.Notifications.Models;
using N73.Notifications.Domin.Entities;

namespace N73.Notifications.Application.Common.Notifications.Services;

public interface ISmsHistoryService
{
    ValueTask<IList<SmsHistory>> GetByFilterAsync(
        FilterPagination filterPagination,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ValueTask<SmsHistory> CreateAsync(
        SmsHistory smsTemplate,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);
}