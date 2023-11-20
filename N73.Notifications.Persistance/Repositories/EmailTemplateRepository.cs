using System.Linq.Expressions;
using N73.Notifications.Domin.Entities;
using N73.Notifications.Persistance.DataContexts;
using N73.Notifications.Persistance.Repositories;

namespace N73.Notifications.Persistance.Repositories;

public class EmailTemplateRepository : EntityRepositoryBase<EmailTemplate, NotificationDbContext>, IEmailTemplateRepository
{
    public EmailTemplateRepository(NotificationDbContext dbContext) : base(dbContext)
    {
    }
    
    public IQueryable<EmailTemplate> Get(
        Expression<Func<EmailTemplate, bool>>? predicate = default,
        bool asNoTracking = false) =>
        base.Get(predicate, asNoTracking);

    public ValueTask<EmailTemplate> CreateAsync(
        EmailTemplate emailTemplate,
        bool saveChange = true,
        CancellationToken cancellationToken = default) =>
        base.CreateAsync(emailTemplate, saveChange, cancellationToken);
}