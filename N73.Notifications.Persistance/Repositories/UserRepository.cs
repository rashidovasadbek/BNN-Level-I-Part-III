using System.Linq.Expressions;
using N73.Notifications.Domin.Entities;
using N73.Notifications.Persistance.DataContexts;

namespace N73.Notifications.Persistance.Repositories;

public class UserRepository : EntityRepositoryBase<User, NotificationDbContext>, IUserRepository
{
    public UserRepository(NotificationDbContext dbContext) : base(dbContext)
    {
    }

    public IQueryable<User> Get(
        Expression<Func<User, bool>>? predicate = default,
        bool asNoTracking = false)
        => base.Get(predicate, asNoTracking);

    public ValueTask<IList<User>> GetByIdsAsync(
        IEnumerable<Guid> userId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default)
        => base.GetByIdsAsync(userId, asNoTracking, cancellationToken);

    public ValueTask<User?> GetByIdAsync(
        Guid userId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default)
        => base.GetByIdAsync(userId, asNoTracking, cancellationToken);
}