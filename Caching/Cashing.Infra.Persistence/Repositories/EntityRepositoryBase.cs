using System.Linq.Expressions;
using Cashing.Infra.Domain.Common.Entities;
using Cashing.Infra.Persistence.cashing;
using Microsoft.EntityFrameworkCore;

namespace Cashing.Infra.Persistence.Repositories;

public abstract class EntityRepositoryBase<TEntity, TContext>(TContext dbContext, ICacheBroker cacheBroker)
    where TEntity : class, IEntity where TContext : DbContext
{
    protected TContext DbContext => dbContext;

    protected IQueryable<TEntity> Get(Expression<Func<TEntity, bool>>? predicate = default, bool asNoTracking = false)
    {
        var initialQuery = DbContext.Set<TEntity>().Where(entity => true);

        if (predicate is not null)
            initialQuery = initialQuery.Where(predicate);

        if (asNoTracking)
            initialQuery = initialQuery.AsNoTracking();
        
        return initialQuery
    }
}