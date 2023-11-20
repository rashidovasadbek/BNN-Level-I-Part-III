using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using N73.Notifications.Domin.Entities;
using N73.Notifications.Persistance.DataContexts;

namespace N73.Notifications.Persistance.Repositories;

public class EmailHistoryRepository : EntityRepositoryBase<EmailHistory, NotificationDbContext>, IEmailHistoryRepository
{
    public EmailHistoryRepository(NotificationDbContext dbContext) : base(dbContext)
    {
    }

    public IQueryable<EmailHistory> Get(
        Expression<Func<EmailHistory, bool>>? predicate = default,
        bool asNoTracking = false) =>
        base.Get(predicate, asNoTracking);
    

    public async ValueTask<EmailHistory> CreateAsync(
        EmailHistory emailHistory,
        bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        if (emailHistory.EmailTemplate is not null)
            DbContext.Entry(emailHistory.EmailTemplate).State = EntityState.Unchanged;

        var createdHistory = await base.CreateAsync(emailHistory, saveChanges, cancellationToken);

        if (emailHistory.EmailTemplate is not null)
            DbContext.Entry(emailHistory.EmailTemplate).State = EntityState.Detached;

        return createdHistory;
    }
}