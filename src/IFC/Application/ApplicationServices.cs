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
        return services;
    }
}