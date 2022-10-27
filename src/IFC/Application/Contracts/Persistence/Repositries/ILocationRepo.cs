namespace IFC.Application.Contracts.Persistence.Repositries;

public interface ILocationRepo
{
    Task CreateLocationAsync(Location location);
    Task DeleteLocationAsync(long? id);
    Task<List<Location>> GetLocationsAsync();
    Task<Location?> GetLocationsAsync(long? id);
}