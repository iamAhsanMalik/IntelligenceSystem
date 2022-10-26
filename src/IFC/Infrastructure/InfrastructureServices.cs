using IFC.Application.Contracts.Application;
using IFC.Infrastructure.Identity;

namespace IFC.Infrastructure;

public static class InfrastructureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentityServices();
        services.AddPersistenceServices(configuration);
        services.AddSingleton<IFileHelpers, FileHelpers>();
        return services;
    }
}


