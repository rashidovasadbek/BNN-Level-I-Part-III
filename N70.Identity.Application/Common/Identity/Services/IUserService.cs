using N70.Identity.Domin.Entities;

namespace N70.Identity.Application.Common.Identity.Services;

public interface IUserService
{
    ValueTask<User?> GetByIdAsync(Guid userid);

    ValueTask<User> UpdateAsync(User user);
}