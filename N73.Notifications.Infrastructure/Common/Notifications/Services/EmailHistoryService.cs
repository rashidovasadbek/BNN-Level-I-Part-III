using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using N73.Notifications.Application.Common.Models.Quering;
using N73.Notifications.Application.Common.Notifications.Services;
using N73.Notifications.Application.Common.Querying.Extensions;
using N73.Notifications.Domin.Entities;
using N73.Notifications.Persistance.Repositories;

namespace N73.Notification.Infrastructure.Common.Notifications.Services;

public class EmailHistoryService : IEmailHistoryService
{
    private readonly IEmailHistoryRepository _emailHistoryRepository;

    public EmailHistoryService(IEmailHistoryRepository emailHistoryRepository)
    {
        _emailHistoryRepository = emailHistoryRepository;
    }


    public async ValueTask<IList<EmailHistory>> GetByFilterAsync(
        FilterPagination filterPagination,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
        ) => 
        await _emailHistoryRepository.Get().ApplyPagination(filterPagination).ToListAsync(cancellationToken);

    public async ValueTask<EmailHistory> CreateAsync(
        EmailHistory smsTemplate,
        bool saveChange = true,
        CancellationToken cancellationToken = default
        ) =>
        await _emailHistoryRepository.CreateAsync(smsTemplate, saveChange, cancellationToken);

}