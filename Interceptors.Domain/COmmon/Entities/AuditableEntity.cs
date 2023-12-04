namespace Interceptors.Domain.COmmon.Entities;

public class AuditableEntity :  IAuditableEntity
{
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset? ModifiedTime { get; set; }
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedTime { get; set; }
}