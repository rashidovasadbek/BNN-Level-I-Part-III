namespace Cashing.Infra.Api.Configurations;

public static partial class HostConfiguration
{
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder.AddCaching().AddExposers().AddIdentityInfrastructure();

        return new(builder);
    }

    public static async ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        await app.SeedDataAsync();
        app.UseExposers();

        return (app);
    }
}