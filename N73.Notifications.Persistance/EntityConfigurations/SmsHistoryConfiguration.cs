using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N73.Notifications.Domin.Entities;

namespace N73.Notifications.Persistance.EntityConfigurations;

public class SmsHistoryConfiguration : IEntityTypeConfiguration<SmsHistory>
{
    public void Configure(EntityTypeBuilder<SmsHistory> builder)
    {
        builder.Property(template => template.SenderPhoneAddress).IsRequired().HasMaxLength(256);
        builder.Property(template => template.ReceiverPhoneAddress).IsRequired().HasMaxLength(256);
    }
}