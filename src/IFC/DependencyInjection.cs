using IFC.Infrastructure.Persistence;
using IFC.Infrastructure.Persistence.Seeding;

namespace IFC;

public static class DependencyInjection
{
    public static IServiceCollection AddIFCServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistenceServices(configuration);
        services.AddControllersWithViews().AddJsonOptions(options =>
                options.JsonSerializerOptions.PropertyNamingPolicy = null);
        // services.AddDistributedMemoryCache();
        services.AddScoped<ISeedDatabase, SeedDatabase>();
        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromSeconds(10);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });
        return services;
    }
}