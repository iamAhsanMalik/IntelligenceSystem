namespace IFC.Infrastructure.Persistence.Repositories;

public interface IIncidentRepo
{
    Task CreateIncidentAsync(Incident incident);
    Task DeleteIncidentAsync(long? id);
    Task<List<Incident>> GetIncidentsAsync();
    Task<Incident?> GetIncidentsAsync(long? id);
}