using System.Linq.Expressions;
using N70.Identity.Domin.Entities;

namespace N70.Identity.Persistace.Repositories.Interfaces;

public interface IRoleRepository
{
    IQueryable<Role> Get(Expression<Func<Role, bool>> predicate);
}