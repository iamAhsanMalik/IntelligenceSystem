namespace IFC.Infrastructure.Persistence.Repositories;

public interface IThreatRepo
{
    Task CreateThreatsAsync(Threat threat);
    Task DeleteThreatsAsync(long? id);
    Task<List<Threat>> GetThreatsAsync();
    Task<Threat?> GetThreatsAsync(long? id);
}