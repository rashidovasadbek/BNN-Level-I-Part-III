using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using N70.Identity.Domin.Entities;
using N70.Identity.Domin.Enums;
using N70.Identity.Persistace.DataContext;

namespace N70.Identity.Persistace.Repositories.Interfaces;

public class RoleRepository : EntityRepositoryBase<Role, IdentityDbContext>,IRoleRepository
{
    public RoleRepository(IdentityDbContext dbContext) : base(dbContext)
    {
    }

    public new IQueryable<Role> Get(Expression<Func<Role, bool>> predicate = default, bool asNoTracking = false)
    {
        return base.Get(predicate, asNoTracking);
    }
}