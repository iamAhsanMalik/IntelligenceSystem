namespace IFC.Application.Contracts.Persistence.Repositries;

public interface IThreatRepo
{
    Task CreateThreatsAsync(Threat threat);
    Task DeleteThreatsAsync(long? id);
    Task<List<Threat>> GetThreatsAsync();
    Task<Threat?> GetThreatsAsync(long? id);
}