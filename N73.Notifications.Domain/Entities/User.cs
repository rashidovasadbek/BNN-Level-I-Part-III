using N73.Notifications.Domin.Common.Entities;
using N73.Notifications.Domin.Enums;

namespace N73.Notifications.Domin.Entities;

public class User : IEntity
{
    public Guid Id { get; set; }

    public string UserName { get; set; } = default!;

    public string PhoneNumber { get; set; } = default!;

    public string EmailAddress { get; set; } = default!;
    
    public RoleType Role { get; set; }
    
    public UserSettings UserSettings { get; set; }
}