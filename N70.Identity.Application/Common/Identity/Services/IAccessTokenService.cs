using N70.Identity.Domin.Entities;

namespace N70.Identity.Application.Common.Identity.Services;

public interface IAccessTokenService
{
    ValueTask<AccessToken> CreateAsync(
        Guid userId,
        string value,
        bool saveChange = true,
        CancellationToken cancellationToken = default);
}