namespace Interceptors.Domain.COmmon.Entities;

public interface IModificationAuditableEntity
{
    Guid? ModifiedByUserId { get; set; }
}