using System.Linq.Expressions;
using N73.Notifications.Domin.Entities;

namespace N73.Notifications.Persistance.Repositories;

public interface ISmsTemplateRepository
{
    IQueryable<SmsTemplate> Get(Expression<Func<SmsTemplate, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<SmsTemplate> CreateAsync(SmsTemplate smsTemplate, bool saveChanges = true,
        CancellationToken cancellationToken = default);
}