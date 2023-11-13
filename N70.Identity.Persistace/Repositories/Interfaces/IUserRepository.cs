using N70.Identity.Domin.Entities;

namespace N70.Identity.Persistace.Repositories;

public interface IUserRepository
{
    ValueTask<User?> GetByIdAsync(Guid userId);

    ValueTask<User> UpdateAsync(User user, bool saveChangesAsync = true, CancellationToken cancellationToken = default);
}