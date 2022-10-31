using Mapster;

namespace IFC.Application;

public static class ApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeHelpers, DateTimeHelpers>();
        services.AddSingleton<IEscaperHelpers, EscaperHelpers>();
        services.AddSingleton<IGeneralHelpers, GeneralHelpers>();
        services.AddSingleton<ISecurityHelpers, SecurityHelpers>();
        services.AddSingleton<IValidatorHelpers, ValidatorHelpers>();
        services.AddSingleton<IGeneratorHelpers, GeneratorHelpers>();

        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }
}