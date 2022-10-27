namespace IFC.Application.Contracts.Persistence.Repositries;

public interface IIncidentRepo
{
    Task CreateIncidentAsync(Incident incident);
    Task DeleteIncidentAsync(long? id);
    Task<List<Incident>> GetIncidentsAsync();
    Task<Incident?> GetIncidentsAsync(long? id);
}