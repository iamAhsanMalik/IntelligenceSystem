using IFC.Application.DTOs.Incident;

namespace IFC.Application.Contracts.Persistence.Repositries;

public interface IIncidentRepo
{
    Task CreateIncidentAsync(Incident incident);
    Task DeleteIncidentAsync(long? id);
    Task<List<IncidentDTO>> GetIncidentsAsync();
    Task<IncidentDTO> GetIncidentsAsync(long? id);
}