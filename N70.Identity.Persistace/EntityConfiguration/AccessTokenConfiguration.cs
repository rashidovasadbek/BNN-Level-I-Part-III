using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N70.Identity.Domin.Entities;

namespace N70.Identity.Persistace.EntityConfiguration;

public class AccessTokenConfiguration : IEntityTypeConfiguration<AccessToken>
{
    public void Configure(EntityTypeBuilder<AccessToken> builder)
    {
        builder.HasOne<User>().WithOne().HasForeignKey<AccessToken>(token => token.UserId);
    }
}