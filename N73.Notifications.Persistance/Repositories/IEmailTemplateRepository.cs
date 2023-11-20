using System.Linq.Expressions;
using N73.Notifications.Domin.Entities;

namespace N73.Notifications.Persistance.Repositories;

public interface IEmailTemplateRepository
{
    IQueryable<EmailTemplate> Get(
        Expression<Func<EmailTemplate, bool>>? predicate = default,
        bool asNoTracking = false);

    ValueTask<EmailTemplate> CreateAsync(
        EmailTemplate emailTemplate, 
        bool savaChanges = true,
        CancellationToken cancellationToken = default);
}