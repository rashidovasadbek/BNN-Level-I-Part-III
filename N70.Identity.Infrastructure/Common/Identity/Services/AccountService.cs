using Microsoft.AspNetCore.Authentication;
using N70.Identity.Application.Common.Enums;
using N70.Identity.Application.Common.Identity.Services;
using N70.Identity.Application.Common.Notifications;
using N70.Identity.Domin.Entities;

namespace N70.Identity.Infrastructure.Common.Identity.Services;

public class AccountService : IAccountService
{
    private readonly IVerificationTokenGeneratorService _verificationTokenGeneratorService;
    private readonly IEmailOrchestrationService _emailOrchestrationService;
    private readonly IUserService _userService;

    public AccountService(
        IVerificationTokenGeneratorService verificationTokenGeneratorService,
        IEmailOrchestrationService emailOrchestrationService,
        IUserService userService
        )
    {
        _verificationTokenGeneratorService = verificationTokenGeneratorService;
        _emailOrchestrationService = emailOrchestrationService;
        _userService = userService;
    }

    public List<User> Users { get; }

    public ValueTask<bool> VerificateAsync(string token, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(token))
            throw new ArgumentNullException("Invalid verification token", nameof(token));

        var verificationTokenResult = _verificationTokenGeneratorService.DecodeToken(token);

        if (!verificationTokenResult.isValid)
            throw new InvalidOperationException("invalid verification token");

        var result = verificationTokenResult.Token.Type switch
        {
            VerificationType.EmailAddressVerification => MarkEmailAsVerifiedAsync(verificationTokenResult.Token.UserId),
            _ => throw new InvalidOperationException("This method is not intended to accept other types of tokens")
        };

        return result;
    }

    public async ValueTask<bool> CreateUserAsync(User user, CancellationToken cancellationToken = default)
    {
        var createdUser = await _userService.CreateAsync(user, true, cancellationToken);

        var verificationToken =
            _verificationTokenGeneratorService.GenerateToken(VerificationType.EmailAddressVerification, createdUser.Id);

        var verificationEmailResult = await _emailOrchestrationService.SendAsync(createdUser.EmailAddress,
            $"Sistemaga xush kelibsiz - {verificationToken}");

        var result = verificationEmailResult;

        return result;
    }
    public ValueTask<bool> MarkEmailAsVerifiedAsync(Guid userId)
    {
        return new(true);
    }
    
}