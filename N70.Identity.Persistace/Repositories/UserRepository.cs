using Microsoft.EntityFrameworkCore;
using N70.Identity.Domin.Entities;

namespace N70.Identity.Persistace.Repositories;

public class UserRepository : EntityRepositoryBase<User> , IUserRepository
{
    public UserRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public ValueTask<User?> GetByIdAsync(Guid userId)
    {
        return base.GetByIdAsync(userId);
    }

    public ValueTask<User> UpdataAsync(User user, bool saveChangeAsync = true,
        CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(user, saveChangeAsync, cancellationToken);
    }
}