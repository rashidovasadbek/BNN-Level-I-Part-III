namespace N67.EduCourse.Api.Configuration;

public static partial class HostConfiguration
{
    public static ValueTask<WebApplicationBuilder> ConfigurAsync(this WebApplicationBuilder builder)
    {
        builder
                .AddPersistence()
                .AddIdentityInfrastructure()
                .AddDevTools()
                .AddExposers();
            
        return new(builder);
    }

    public static ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        app
            .UseDevTools()
            .UseExposers();
        return new(app);
    }
}