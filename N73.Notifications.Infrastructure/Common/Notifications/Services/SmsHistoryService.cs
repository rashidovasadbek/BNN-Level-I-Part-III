using Microsoft.EntityFrameworkCore;
using N73.Notifications.Application.Common.Models.Quering;
using N73.Notifications.Application.Common.Notifications.Models;
using N73.Notifications.Application.Common.Notifications.Services;
using N73.Notifications.Application.Common.Querying.Extensions;
using N73.Notifications.Domin.Entities;
using N73.Notifications.Persistance.Repositories;

namespace N73.Notification.Infrastructure.Common.Notifications.Services;

public class SmsHistoryService : ISmsHistoryService
{
    private readonly ISmsHistoryRepository _smsHistoryRepository;

    public SmsHistoryService(ISmsHistoryRepository smsHistoryRepository)
    {
        _smsHistoryRepository = smsHistoryRepository;
    }

    public async ValueTask<IList<SmsHistory>> GetByFilterAsync(
        FilterPagination filterPagination,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
        ) =>
        await _smsHistoryRepository.Get().ApplyPagination(filterPagination).ToListAsync(cancellationToken);


    public async ValueTask<SmsHistory> CreateAsync(
        SmsHistory smsTemplate,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
        ) =>
        await _smsHistoryRepository.CreateAsync(smsTemplate, saveChanges, cancellationToken);
}