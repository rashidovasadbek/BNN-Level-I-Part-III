using Microsoft.EntityFrameworkCore;
using N70.Identity.Persistace.DataContext;

namespace N70.Identity.Api.Configuration;

public static partial class HostConfiguration
{
    private static WebApplicationBuilder AddPersistance(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<IdentityDbContext>(optoins =>
            optoins.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        return builder;
    }
}