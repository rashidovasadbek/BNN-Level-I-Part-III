﻿using N73.Notifications.Domin.Entities;

namespace N73.Notifications.Application.Common.Identity.Services;

public interface IUserSettingsService
{
    ValueTask<UserSettings> GetByIdAsync(
        Guid userSettingsId, 
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);
}