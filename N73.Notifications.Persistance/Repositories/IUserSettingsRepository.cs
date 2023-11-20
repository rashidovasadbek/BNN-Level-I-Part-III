using N73.Notifications.Domin.Entities;

namespace N73.Notifications.Persistance.Repositories;

public interface IUserSettingsRepository
{
    ValueTask<UserSettings?> GetByIdAsync(
        Guid userId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);
}