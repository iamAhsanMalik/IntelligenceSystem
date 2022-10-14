using IFC.Domain.Enums;
using IFC.Infrastructure.Persistence.Seeding;

namespace IFC.Infrastructure.Persistence;
internal static class PersistenceServices
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        // DB Context Setting
        services.AddDbContext<IFCDbContext>(options =>
           options.UseSqlServer(configuration.GetConnectionString(nameof(ConnectionStrings.DefaultConnection))));
        // services.AddDbContext<IFCDbContext>(options =>
        //    options.UseSqlite(configuration.GetConnectionString(nameof(ConnectionStrings.SqliteConnection))));
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

        // Identity Services
        services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<IFCDbContext>().AddDefaultTokenProviders();

        return services;
    }

    public static async Task<WebApplication> ApplyMigrationAndSeedingAsync(this WebApplication request)
    {
        using (var scope = request.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var dbContext = services.GetRequiredService<IFCDbContext>();
            var dbSeeder = services.GetRequiredService<ISeedDatabase>();
            await dbContext.Database.MigrateAsync();
            await dbSeeder.DatabaseSeederAsync();
        }
        return request;
    }
}