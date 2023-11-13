using Microsoft.EntityFrameworkCore;
using N70.Identity.Domin.Entities;
using N70.Identity.Persistace.DataContext;

namespace N70.Identity.Persistace.Repositories;

public class UserRepository : EntityRepositoryBase<User, IdentityDbContext> , IUserRepository
{
    public UserRepository(IdentityDbContext dbContext) : base(dbContext)
    {
    }
    
    public ValueTask<User?> GetByIdAsync(Guid userId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return base.GetByIdAsync(userId, asNoTracking, cancellationToken);
    }

    private ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(user, saveChanges, cancellationToken);
    }
    public ValueTask<User> UpdataAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(user, saveChanges, cancellationToken);
    }
}