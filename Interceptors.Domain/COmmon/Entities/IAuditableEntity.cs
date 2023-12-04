namespace Interceptors.Domain.COmmon.Entities;

public interface IAuditableEntity : ISoftDeletedEntity
{
    DateTimeOffset CreatedTime { get; set; }
    
    DateTimeOffset? ModifiedTime { get; set; }
}