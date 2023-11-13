using Microsoft.EntityFrameworkCore;
using N70.Identity.Application.Common.Identity.Services;
using N70.Identity.Domin.Entities;
using N70.Identity.Persistace.Repositories;

namespace N70.Identity.Infrastructure.Common.Identity.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public ValueTask<User?> GetByIdAsync(Guid userId, bool asNoTracing = false, CancellationToken cancellationToken = default)
    {
        return _userRepository.GetByIdAsync(userId, asNoTracing, cancellationToken);
    }

    public async ValueTask<User?> GetByEmailAddressAsync(string emailAddress, bool asNoTracking = false,
        CancellationToken cancellationToken = default)
    {
        return await _userRepository
            .Get(asNoTracking: asNoTracking)
            .Include(user => user.Role)
            .SingleOrDefaultAsync(user => user.EmailAddress == emailAddress, cancellationToken: cancellationToken);
    }

    public ValueTask<User> CreateAsync(User user, bool saveChange = true, CancellationToken cancellationToken = default)
    {
        return _userRepository.CreateAsync(user, saveChange, cancellationToken);
    }

    public ValueTask<User> UpdateAsync(User user, bool saveChange = true, CancellationToken cancellationToken = default)
    {
        return _userRepository.UpdateAsync(user, saveChange, cancellationToken);
    }
}