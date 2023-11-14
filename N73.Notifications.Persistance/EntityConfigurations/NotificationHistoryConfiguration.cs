using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N73.Notifications.Domin.Common.Entities;
using N73.Notifications.Domin.Entities;
using N73.Notifications.Domin.Enums;

namespace N73.Notifications.Persistance.EntityConfigurations;

public class NotificationHistoryConfiguration : IEntityTypeConfiguration<NotificationHistory>
{
    public void Configure(EntityTypeBuilder<NotificationHistory> builder)
    {
        builder.Property(template => template.Content).HasMaxLength(129_536);

        builder
            .ToTable("NotificationHistories")
            .HasDiscriminator(history => history.Type)
            .HasValue<EmailHistory>(NotificationType.Email)
            .HasValue<SmsHistory>(NotificationType.Sms);

        builder.HasOne<NotificationTemplate>(history => history.Template)
            .WithMany(template => template.Histories)
            .HasForeignKey(history => history.TemplateId);

    }
}