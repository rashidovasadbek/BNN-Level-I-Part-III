using N70.Identity.Domin.Entities;

namespace N70.Identity.Application.Common.Identity.Services;

public interface IUserService
{
    ValueTask<User?> GetByIdAsync(Guid userId, bool asNoTracing = false, CancellationToken cancellationToken = default);

    ValueTask<User?> GetByEmailAddressAsync(string emailAddress, bool asNoTracing = false,
        CancellationToken cancellationToken = default);

    ValueTask<User> CreateAsync(User user, bool saveChange = true, CancellationToken cancellationToken = default);
    ValueTask<User> UpdateAsync(User user, bool saveChange = true, CancellationToken cancellationToken = default);
}