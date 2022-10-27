namespace IFC.Infrastructure.Persistence.Interfaces;

public interface IThreat
{
    Task CreateApprovalsAsync(Threat threat);
    Task DeleteApprovalsAsync(long? id);
    Task<List<Threat>> GetApprovalsAsync();
    Task<Threat?> GetApprovalsAsync(long? id);
}
