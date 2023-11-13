using N70.Identity.Domin.Common;

namespace N70.Identity.Domin.Entities;

public class AccessToken : IEntity
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }

    public string Value { get; set; } = default!;
    
    public bool IsRevoked { get; set; }
    
    public DateTime CreatedTime { get; set; }
}