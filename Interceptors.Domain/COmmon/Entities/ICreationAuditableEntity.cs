namespace Interceptors.Domain.COmmon.Entities;

public interface ICreationAuditableEntity
{
    Guid CreatedByUserId { get; set; }
}