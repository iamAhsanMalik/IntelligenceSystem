namespace IFC;

public static class DependencyInjection
{
    public static IServiceCollection AddIFCServices(this IServiceCollection services)
    {
        services.AddControllersWithViews().AddJsonOptions(options =>
                options.JsonSerializerOptions.PropertyNamingPolicy = null);
        // services.AddDistributedMemoryCache();
        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromSeconds(10);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });
        return services;
    }
}