namespace Notifications.Api;

public static partial class HostConfiguration
{
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder.AddNotificationInfrastructure();

        return new(builder);
    }
}