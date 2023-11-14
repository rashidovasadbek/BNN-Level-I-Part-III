using System.Linq.Expressions;
using N73.Notifications.Domin.Entities;

namespace N73.Notifications.Persistance.Repositories;

public interface IEmailHistoryRepository
{
    IQueryable<EmailHistory> Get(Expression<Func<EmailHistory, bool>>? predicate = default,
       bool asNoTracking = false);

    ValueTask<EmailHistory> CreateAsync(EmailHistory emailHistory, bool saveChanges = true,
        CancellationToken cancellationToken = default);
}