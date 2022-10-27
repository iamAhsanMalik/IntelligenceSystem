using IFC.DataTableServices.CsvService;
using IFC.DataTableServices.ExcelService;
using IFC.DataTableServices.ExportService;
using IFC.DataTableServices.HtmlService;
using Newtonsoft.Json.Converters;

namespace IFC;

public static class DependencyInjection
{
    public static IServiceCollection AddIFCServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplicationServices().AddInfrastructureServices(configuration);
        services.AddScoped<IExportService, ExportService>();
        services.AddScoped<IExcelService, ExcelService>();
        services.AddScoped<ICsvService, CsvService>();
        services.AddScoped<IHtmlService, HtmlService>();
        var authorizeFilter = new AuthorizeFilter(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build());
        services.AddControllersWithViews(options => options.Filters.Add(authorizeFilter)).AddNewtonsoftJson(options => options.SerializerSettings.Converters.Add(new StringEnumConverter())).AddJsonOptions(options =>
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