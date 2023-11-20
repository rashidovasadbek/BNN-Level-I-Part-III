using Microsoft.EntityFrameworkCore;
using N73.Notifications.Application.Common.Identity.Services;
using N73.Notifications.Domin.Entities;
using N73.Notifications.Domin.Enums;
using N73.Notifications.Persistance.Repositories;

namespace N73.Notification.Infrastructure.Common.Identity.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public ValueTask<IList<User>> GetByIdsAsync(
        IEnumerable<Guid> usersId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default)
        => _userRepository.GetByIdsAsync(usersId, asNoTracking, cancellationToken);
   

    public async ValueTask<User?> GetSystemUserAsync(
        bool asNoTracking = false,
        CancellationToken cancellationToken = default)
    {
        return await _userRepository.Get(user => user.Role == RoleType.System, asNoTracking)
            .Include(user => user.UserSettings)
            .SingleOrDefaultAsync(cancellationToken);
    }

    public ValueTask<User?> GetByIdAsync(
        Guid userId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default)
        => _userRepository.GetByIdAsync(userId, asNoTracking, cancellationToken);
}