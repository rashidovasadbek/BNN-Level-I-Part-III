using System.Linq.Expressions;
using N70.Identity.Domin.Entities;
using N70.Identity.Domin.Enums;

namespace N70.Identity.Persistace.Repositories.Interfaces;

public interface IRoleRepository
{
    IQueryable<Role> Get(Expression<Func<Role, bool>> predicate = default, bool asNoTracking = false);
}