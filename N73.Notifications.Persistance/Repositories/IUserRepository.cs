using System.Linq.Expressions;
using N73.Notifications.Domin.Entities;

namespace N73.Notifications.Persistance.Repositories;

public interface IUserRepository
{
    IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<IList<User>> GetByIdsAsync(
        IEnumerable<Guid> userId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
        );

    ValueTask<User?> GetByIdAsync(
        Guid userId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
        );
}