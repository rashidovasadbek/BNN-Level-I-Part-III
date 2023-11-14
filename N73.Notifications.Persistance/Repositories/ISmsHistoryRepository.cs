using System.Linq.Expressions;
using N73.Notifications.Domin.Entities;

namespace N73.Notifications.Persistance.Repositories;

public interface ISmsHistoryRepository
{
    IQueryable<SmsHistory> Get(Expression<Func<SmsHistory, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<SmsHistory> CreateAsync(SmsHistory smsHistory, bool saveChanges = true,
        CancellationToken cancellationToken = default);
}