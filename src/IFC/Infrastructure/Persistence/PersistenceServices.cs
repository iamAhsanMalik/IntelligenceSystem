using IFC.Application.Contracts.Persistence.Repositries;
using IFC.Infrastructure.Persistence.Repositories;

namespace IFC.Infrastructure.Persistence;
internal static class PersistenceServices
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        switch (configuration["DatabaseProvider"])
        {
            case nameof(DatabaseProvider.MySql):
                services.AddDbContext<IFCDbContext>(options =>
                   options.UseMySql(configuration.GetConnectionString(nameof(ConnectionStrings.MySqlConnection)), ServerVersion.AutoDetect(configuration.GetConnectionString(nameof(ConnectionStrings.MySqlConnection)))));
                break;
            case nameof(DatabaseProvider.Sqlite):
                services.AddDbContext<IFCDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString(nameof(ConnectionStrings.SqliteConnection))));
                break;
            default:
                services.AddDbContext<IFCDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString(nameof(ConnectionStrings.SqlServerConnection))));
                break;
        }
        services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<IFCDbContext>().AddDefaultTokenProviders();
        services.AddScoped<ISeedDatabase, SeedDatabase>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        //Repositories Registration
        //services.AddScoped<IApprovalRepo, ApprovalRepo>();
        //services.AddScoped<IAddressRepo, AddressRepo>();
        //services.AddScoped<IAffiliateRepo, AffiliateRepo>();
        //services.AddScoped<IApprovalRequestTypeRequestTypeRepo, ApprovalRequestTypeRequestTypeRepo>();
        //services.AddScoped<ICityRepo, CityRepo>();
        //services.AddScoped<ICoreHeadQuarterRepo, CoreHeadQuarterRepo>();
        //services.AddScoped<IDistrictRepo, DistrictRepo>();
        //services.AddScoped<IFunderRepo, FunderRepo>();
        //services.AddScoped<IIncidentRepo, IncidentRepo>();
        //services.AddScoped<ILocationRepo, LocationRepo>();
        //services.AddScoped<IIncidentRepo, IncidentRepo>();
        //services.AddScoped<IOperationalBaseRepo, OperationalBaseRepo>();
        //services.AddScoped<IOrganizationRepo, OrganizationRepo>();
        //services.AddScoped<IRelationTypeRepo, IRelationTypeRepo>();
        //services.AddScoped<ISectorHeadQuarterRepo, SectorHeadQuarterRepo>();
        //services.AddScoped<ISocialMediaProfileRepo, SocialMediaProfileRepo>();
        //services.AddScoped<ITerroristFacilitatorsDetailRepo, ITerroristFacilitatorsDetailRepo>();
        //services.AddScoped<ITerroristFamilyDetailRepo, ITerroristFamilyDetailRepo>();
        //services.AddScoped<ITerroristProfileRepo, ITerroristProfileRepo>();
        //services.AddScoped<ITerroristInvolvementRepo, ITerroristInvolvementRepo>();
        //services.AddScoped<IThreatRepo, IThreatRepo>();
        //services.AddScoped<IWingRepo, WingRepo>();


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