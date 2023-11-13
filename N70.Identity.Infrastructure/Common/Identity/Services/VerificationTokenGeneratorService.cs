using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;
using N70.Identity.Application.Common.Enums;
using N70.Identity.Application.Common.Identity.Models;
using N70.Identity.Application.Common.Identity.Services;
using N70.Identity.Application.Common.Settings;
using Newtonsoft.Json;

namespace N70.Identity.Infrastructure.Common.Identity.Services;

public class VerificationTokenGeneratorService : IVerificationTokenGeneratorService
{
    private readonly IDataProtector _dataProtector;
    private readonly VerificationTokenSettings _verificationTokenSettings;

    public VerificationTokenGeneratorService(
       IOptions<VerificationTokenSettings> verificationTokenSettings,
        IDataProtectionProvider dataProtectionProvider)
    {
        _verificationTokenSettings = verificationTokenSettings.Value;
        _dataProtector = dataProtectionProvider.CreateProtector(_verificationTokenSettings.IdentityVerificationTokenPurpose);
    }   
    
    public string GenerateToken(VerificationType verificationType, Guid userId)
    {
        var verificationToken = new VerificationToken()
        {
            UserId = userId,
            Type = verificationType,
            ExpiryTime = DateTimeOffset.UtcNow.AddMinutes(_verificationTokenSettings.IdentityVerificationExpirationDurationInMinutes)
        };

        return _dataProtector.Protect(JsonConvert.SerializeObject(verificationToken));
    }

    public (VerificationToken Token, bool isValid) DecodeToken(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
            throw new ArgumentNullException(nameof(token));

        var unprotectedToken = _dataProtector.Unprotect(token);
        var verificationToken = JsonConvert.DeserializeObject<VerificationToken>(unprotectedToken) ??
                                throw new ArgumentException("invalid verification model", nameof(token));

        return (verificationToken, verificationToken.ExpiryTime > DateTimeOffset.UtcNow);
    }
}