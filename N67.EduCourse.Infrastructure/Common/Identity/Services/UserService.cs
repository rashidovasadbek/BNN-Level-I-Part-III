using System.Linq.Expressions;
using N67.EduCourse.Application.Common.Identity.Services;
using N67.EduCourse.Domin.DTOs;
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

    public IQueryable<UserDto> Get(Expression<Func<UserDto, bool>>? predicate = null)
        => predicate != null ? _appDbContext.Users.Where(predicate) : _appDbContext.Users;
    

    public ValueTask<UserDto?> GetByIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return _appDbContext.Users.FindAsync(userId);
    }

    public async ValueTask<UserDto> CreateAsync(UserDto userDto, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        userDto.Id = Guid.Empty;
        await _appDbContext.Users.AddAsync(userDto, cancellationToken);

        if (saveChanges)
            await _appDbContext.SaveChangesAsync();

        return userDto;
    }

    public async ValueTask<UserDto> UpdateAsync(UserDto userDto, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundUser = _appDbContext.Users.FirstOrDefault(dbUser => dbUser.Id == userDto.Id);

        _appDbContext.Users.Update(foundUser);

        if (saveChanges)
            await _appDbContext.SaveChangesAsync(cancellationToken);
       
        return foundUser;
    }

    public async ValueTask<UserDto> DeleteAsync(UserDto userDto, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        _appDbContext.Users.Remove(userDto);

        if (saveChanges)
            await _appDbContext.SaveChangesAsync(cancellationToken);

        return userDto;
    }

    public async ValueTask<UserDto> DeleteAsync(Guid userId, bool saveChanges = true, CancellationToken cancellationToken = default)
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