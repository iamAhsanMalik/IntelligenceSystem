
namespace IFC.Infrastructure.Identity;

public static class IdentityServices
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services)
    {

        // Authentication Configurations Options
        services.Configure<IdentityOptions>(options =>
        {
            // Password settings.
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 3;
            options.Password.RequiredUniqueChars = 0;

            // Lockout settings.
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;

            // User settings.
            //options.User.AllowedUserNameCharacters = AppConstants.AllowedUserNameCharacters;
            options.User.RequireUniqueEmail = true;
        });
        services.AddHttpContextAccessor();
        services.AddScoped<IUserInfoService, UserInfoService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IMapper, Mapper>();
        return services;
    }
}