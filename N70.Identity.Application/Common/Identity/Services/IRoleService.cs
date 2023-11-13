using N70.Identity.Domin.Entities;
using N70.Identity.Domin.Enums;

namespace N70.Identity.Application.Common.Identity.Services;

public interface IRoleService
{
    ValueTask<Role?> GetByTypeAsync(RoleType roleType, bool asNoTracking = false, CancellationToken cancellationToken = default);
}