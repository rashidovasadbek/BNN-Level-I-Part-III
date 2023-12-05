using System.Linq.Expressions;
using Cashing.Infra.Domain.Common.Entities;

namespace Cashing.Infra.Application.Common.Identity.Service;

public interface IUserService
{
    IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<User?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);
    
    ValueTask<User> DeleteByIdAsync(Guid userId, bool saveChanges = true, CancellationToken cancellationToken = default);
}