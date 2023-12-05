using Cashing.Infra.Api.Data;
using Cashing.Infra.Application.Common.Identity.Service;
using Cashing.Infra.Infrastructure.Common.Cashing;
using Cashing.Infra.Infrastructure.Common.Identity.Services;
using Cashing.Infra.Infrastructure.Common.Settings;
using Cashing.Infra.Persistence.cashing;
using Cashing.Infra.Persistence.DataContexts;
using Cashing.Infra.Persistence.Repositories;
using Cashing.Infra.Persistence.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Cashing.Infra.Api.Configurations;

public static partial class HostConfiguration
{
    private static WebApplicationBuilder AddCaching(this WebApplicationBuilder builder)
    {
        //register cache settings
        builder.Services.Configure<CacheSettings>(builder.Configuration.GetSection(nameof(CacheSettings)));
        
        //register lazy memory cache
        builder.Services.AddLazyCache();
        builder.Services.AddSingleton<ICacheBroker, LazyMemoryCacheBroker>();

        return builder;
    }
    
    private static WebApplicationBuilder AddIdentityInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<IdentityDbContext>(
            options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
        
        // register repositories
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        
        //register services
        builder.Services.AddScoped<IUserService, UserService>();

        return builder;
    }

   
    private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen();

        return builder;
    }
    
    private static async ValueTask<WebApplication> SeedDataAsync(this WebApplication app)
    {
        var serviceScope = app.Services.CreateScope();
        await serviceScope.ServiceProvider.InitializeSeedAsync();

        return app;
    }
    
    private static WebApplication UseExposers(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.MapControllers();

        return app;
    }
   
}