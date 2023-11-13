using N70.Identity.Domin.Entities;

namespace N70.Identity.Application.Common.Identity.Services;

public interface IAccountService
{
    List<User> Users { get; }

    ValueTask<bool> VerificateAsync(string token);

    ValueTask<User> CreateUserAsync(User user);
}