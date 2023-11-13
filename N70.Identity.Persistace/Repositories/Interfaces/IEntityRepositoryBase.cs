using System.Linq.Expressions;
using N70.Identity.Domin.Common;

namespace N70.Identity.Persistace.Repositories.Interfaces;

public interface IEntityRepositoryBase<TEntity> where TEntity : class, IEntity
{
    IQueryable<TEntity> Get(Expression<Func<TEntity, bool>>? predicate, bool asNoTracing = true);

    ValueTask<TEntity?> GetByIdAsync(Guid id, bool asNoTracking = true,
        CancellationToken cancellationToken = default);

    ValueTask<IList<TEntity>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = true,
        CancellationToken cancellationToken = default);

    ValueTask<TEntity> CreateAsync(TEntity entity, bool saveChange = true,
        CancellationToken cancellationToken = default);

    ValueTask<TEntity> UpdateAsync(TEntity entity, bool saveChange = true,
        CancellationToken cancellationToken = default);

    ValueTask<TEntity> DeleteAsync(TEntity entity, bool saveChange = true,
        CancellationToken cancellationToken = default);

    ValueTask<TEntity> DeleteByIdAsync(Guid id, bool saveChange = true,
        CancellationToken cancellationToken = default);
}