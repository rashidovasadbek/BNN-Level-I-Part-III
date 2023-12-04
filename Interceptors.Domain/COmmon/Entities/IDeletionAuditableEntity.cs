namespace Interceptors.Domain.COmmon.Entities;

public interface IDeletionAuditableEntity
{
    Guid? DeletedByUserId { get; set; }
}