using N73.Notifications.Application.Common.Identity.Services;
using N73.Notifications.Domin.Entities;

namespace N73.Notification.Infrastructure.Common.Identity.Services;

public class UserSettingsService : IUserSettingsService
{
    private readonly IUserSettingsService _userSettingsService;

    public UserSettingsService(IUserSettingsService userSettingsService)
    {
        _userSettingsService = userSettingsService;
    }

    public ValueTask<UserSettings> GetByIdAsync(
        Guid userSettingsId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default)
        => _userSettingsService.GetByIdAsync(userSettingsId, asNoTracking, cancellationToken);
}