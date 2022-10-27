using Newtonsoft.Json.Converters;

namespace IFC;

public static class DependencyInjection
{
    public static IServiceCollection AddIFCServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplicationServices().AddInfrastructureServices(configuration);
        services.AddControllersWithViews(options => options.Filters.Add(new AuthorizeFilter(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build()))).AddJsonOptions(options =>
                options.JsonSerializerOptions.PropertyNamingPolicy = null).AddNewtonsoftJson(options => options.SerializerSettings.Converters.Add(new StringEnumConverter()));

     
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