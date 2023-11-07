using System.Linq.Expressions;
using N67.EduCourse.Domin.DTOs;
using N67.EduCourse.Domin.Entities;

namespace N67.EduCourse.Application.Common.Identity.Services;

public interface IUserService
{
    IQueryable<UserDto> Get(Expression<Func<UserDto, bool>>? predicate = null);

    ValueTask<UserDto?> GetByIdAsync(Guid userId, CancellationToken cancellationToken = default);

    ValueTask<UserDto> CreateAsync(UserDto userDto, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<UserDto> UpdateAsync(UserDto userDto, bool saveChanges = true, CancellationToken cancellationToken = default);
    
    ValueTask<UserDto> DeleteAsync(UserDto userDto, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<UserDto> DeleteAsync(Guid userId, bool saveChanges = true, CancellationToken cancellationToken = default);
}