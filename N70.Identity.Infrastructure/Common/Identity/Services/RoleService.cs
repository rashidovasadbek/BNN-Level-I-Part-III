using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using N70.Identity.Application.Common.Identity.Services;
using N70.Identity.Domin.Entities;
using N70.Identity.Domin.Enums;
using N70.Identity.Persistace.Repositories.Interfaces;

namespace N70.Identity.Infrastructure.Common.Identity.Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async ValueTask<Role?> GetByTypeAsync(RoleType roleType, bool asNoTracking,
        CancellationToken cancellationToken = default)
        => await _roleRepository.Get(asNoTracking: asNoTracking)
            .SingleOrDefaultAsync(role => role.Type == roleType, cancellationToken);
}