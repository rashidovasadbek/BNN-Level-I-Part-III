using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N73.Notifications.Domin.Entities;

namespace N73.Notifications.Persistance.EntityConfigurations;

public class UserSettingsConfiguration : IEntityTypeConfiguration<UserSettings>
{
    public void Configure(EntityTypeBuilder<UserSettings> builder)
    {
        builder.HasOne<User>().WithOne(user => user.UserSettings).HasForeignKey<UserSettings>(settings => settings.Id);
    }
}