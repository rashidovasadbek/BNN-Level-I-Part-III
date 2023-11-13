using N70.Identity.Application.Common.Enums;
using N70.Identity.Application.Common.Identity.Models;

namespace N70.Identity.Application.Common.Identity.Services;

public interface IVerificationTokenGeneratorService
{
    string GenerateToken(VerificationType verificationType, Guid userId);

    (VerificationToken Token, bool isValid) DecodeToken(string token);
}