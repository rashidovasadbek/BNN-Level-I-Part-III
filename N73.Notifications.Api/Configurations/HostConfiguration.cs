namespace Notifications.Api;

public static partial class HostConfiguration
{
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder
            .AddMappers()
            .AddExposers()
            .AddValidators()
            .AddIdentityInfrastructure()
            .AddPersistence()
            .AddNotificationInfrastructure()
            .AddDevTools();

        return new(builder);
    }

    public static ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        app.UseExposers().UseDevTools();

        return new(app);
    }
}