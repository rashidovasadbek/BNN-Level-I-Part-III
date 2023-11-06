using System.Linq.Expressions;
using N67.EduCourse.Application.Common.Identity.Services;
using N67.EduCourse.Domin.Entities;
using Persistance.DataContext;

namespace N67.EduCourse.Infrastructure.Common.Identity.Services;

public class UserService : IUserService
{
    private readonly AppDBContext _appDbContext;

    public UserService(AppDBContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public IQueryable<User> Get(Expression<Func<User, bool>>? predicate = null)
        => predicate != null ? _appDbContext.Users.Where(predicate) : _appDbContext.Users;

    public ValueTask<User?> GetByIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return _appDbContext.Users.FindAsync(userId);
    }

    public async ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        user.Id = Guid.Empty;
        await _appDbContext.Users.AddAsync(user, cancellationToken);

        if (saveChanges)
            await _appDbContext.SaveChangesAsync();

        return user;
    }

    public async ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundUser = _appDbContext.Users.FirstOrDefault(dbUser => dbUser.Id == user.Id);

        _appDbContext.Users.Update(foundUser);

        if (saveChanges)
            await _appDbContext.SaveChangesAsync(cancellationToken);
       
        return foundUser;
    }

    public async ValueTask<User> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        _appDbContext.Users.Remove(user);

        if (saveChanges)
            await _appDbContext.SaveChangesAsync(cancellationToken);

        return user;
    }

    public async ValueTask<User> DeleteAsync(Guid userId, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var founduser = _appDbContext.Users.Find(userId);

        if (founduser is null)
            throw new InvalidOperationException($"User with id {userId} not found.");

        _appDbContext.Users.Remove(founduser);

        if (saveChanges)
            await _appDbContext.SaveChangesAsync(cancellationToken);

        return founduser;
    }
}