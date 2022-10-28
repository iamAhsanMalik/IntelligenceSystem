using IFC.Application.DTOs.Threat;

namespace IFC.Application.Contracts.Persistence.Repositries;

public interface IThreatRepo
{
    Task CreateThreatsAsync(Threat threat);
    Task DeleteThreatsAsync(long? id);
    Task<List<ThreatDTO>> GetThreatsAsync();
    Task<ThreatDTO> GetThreatsAsync(long? id);
}