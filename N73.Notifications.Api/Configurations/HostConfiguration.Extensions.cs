using Microsoft.EntityFrameworkCore;
using N73.Notifications.Persistance.DataContexts;

namespace Notifications.Api;

public static partial class HostConfiguration
{
    private static WebApplicationBuilder AddNotificationInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<NotificationDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("NotificationsDatabaseConnection")));

        return builder;
    }
}