using N70.Identity.Domin.Entities;

namespace N70.Identity.Persistace.Repositories.Interfaces;

public interface IAccessTokenRepository
{
    ValueTask<AccessToken> CreateAsync(AccessToken accessToken, bool saveChange = true,
        CancellationToken cancellationToken = default);
}