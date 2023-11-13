using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using N70.Identity.Domin.Entities;

namespace N70.Identity.Persistace.Repositories.Interfaces;

public class RoleRepository : EntityRepositoryBase<Role>,IRoleRepository
{
    public RoleRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public IQueryable<Role> Get(Expression<Func<Role, bool>> predicate)
    {
        return base.Get(predicate);
    }
}