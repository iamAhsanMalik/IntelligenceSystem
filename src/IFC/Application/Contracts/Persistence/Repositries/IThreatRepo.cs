using IFC.Application.DTOs.Threat;

namespace IFC.Application.Contracts.Persistence.Repositries;

public interface IThreatRepo
{
    Task CreateThreatAsync(Threat threat);
    Task DeleteThreatAsync(long? id);
    Task<List<ThreatDTO>> GetThreatsAsync();
    Task<ThreatDTO> GetThreatsAsync(long? id);
}