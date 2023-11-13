using System.Data.Common;
using N70.Identity.Domin.Entities;
using N70.Identity.Persistace.DataContext;
using N70.Identity.Persistace.Repositories.Interfaces;

namespace N70.Identity.Persistace.Repositories;

public class AccessTokenRepository : EntityRepositoryBase<AccessToken, IdentityDbContext>, IAccessTokenRepository
{
    public AccessTokenRepository(IdentityDbContext dbContext) : base(dbContext)
    {
    }
    
    public ValueTask<AccessToken> CreateAsync(AccessToken token, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(token, saveChanges, cancellationToken);
    }
}