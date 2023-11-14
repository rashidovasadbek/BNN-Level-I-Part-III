using System.Net;
using System.Security.Authentication;
using Microsoft.AspNetCore.Http;
using N70.Identity.Application.Common.Identity.Models;
using N70.Identity.Application.Common.Identity.Services;
using N70.Identity.Application.Common.Notifications;
using N70.Identity.Domin.Entities;
using N70.Identity.Domin.Enums;

namespace N70.Identity.Infrastructure.Common.Identity.Services;

public class AuthService : IAuthService
{
    private readonly IUserService _userService;
    private readonly IRoleService _roleService;
    private readonly ITokenGeneratorService _tokenGeneratorService;
    private readonly IPasswordHasherService _passwordHasherService;
    private readonly IAccountService _accountService;
    private readonly IEmailOrchestrationService _emailOrchestrationService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IAccessTokenService _accessTokenService;

    public AuthService(
        IUserService userService,
        IRoleService roleService,
        ITokenGeneratorService tokenGeneratorService,
        IPasswordHasherService passwordHasherService,
        IAccountService accountService,
        IEmailOrchestrationService emailOrchestrationService,
        IHttpContextAccessor httpContextAccessor,
        IAccessTokenService accessTokenService
        )
    {
        _userService = userService;
        _roleService = roleService;
        _tokenGeneratorService = tokenGeneratorService;
        _passwordHasherService = passwordHasherService;
        _accountService = accountService;
        _emailOrchestrationService = emailOrchestrationService;
        _httpContextAccessor = httpContextAccessor;
        _accessTokenService = accessTokenService;
    }
    
    public async ValueTask<bool> RegisterAsync(RegistrationDetails registrationDetails, CancellationToken cancellationToken = default)
    {
        var foundUser =
            await _userService.GetByEmailAddressAsync(registrationDetails.EmailAddress, true, cancellationToken);

        if (foundUser is not null)
            throw new InvalidOperationException("User with this email address already exists.");

        var defaultRole = await _roleService.GetByTypeAsync(RoleType.Guest, true, cancellationToken) ??
                          throw new InvalidOperationException("Role with this type doesn't exist");
        
        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = registrationDetails.FirstName,
            LastName = registrationDetails.LastName,
            Age = registrationDetails.Age,
            EmailAddress = registrationDetails.EmailAddress,
            PasswordHash = _passwordHasherService.HashPassword(registrationDetails.Password),
            RoleId = defaultRole.Id
        };

        return await _accountService.CreateUserAsync(user, cancellationToken);
    }

    public async ValueTask<string> LoginAsync(LoginDetails loginDetails, CancellationToken cancellationToken = default)
    {
        var foundUser = await _userService.GetByEmailAddressAsync(loginDetails.EmailAddress, true, cancellationToken);

        var test = new
        {
            IPAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress
        };

        if (foundUser is null ||
            !_passwordHasherService.ValidatePassword(loginDetails.Password, foundUser.PasswordHash))
                throw new AuthenticationException("Login details are invalid, contact support.");

        var accessToken = _tokenGeneratorService.GetToken(foundUser);
        await _accessTokenService.CreateAsync(foundUser.Id, accessToken, cancellationToken: cancellationToken);

        return accessToken;
    }

    public async ValueTask<bool> GrandRoleAsync(Guid userId, string roleType, Guid actionUserId,
        CancellationToken cancellationToken = default)
    {
        var user = await _userService.GetByIdAsync(userId) ?? throw new InvalidOperationException();
        _ = await _userService.GetByIdAsync(actionUserId) ?? throw new InvalidOperationException();

        if (!Enum.TryParse(roleType, out RoleType roleValue)) throw new InvalidOperationException();
        var role = await _roleService.GetByTypeAsync(roleValue) ?? throw new InvalidOperationException();

        user.RoleId = role.Id;

        await _userService.UpdateAsync(user);

        return true;
    }
}