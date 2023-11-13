using N70.Identity.Application.Common.Enums;

namespace N70.Identity.Application.Common.Identity.Models;

public class VerificationToken
{
    public Guid Id { get; set; }
    
    public VerificationType Type { get; set; }
    
    public DateTimeOffset ExpiryTime { get; set; }
}