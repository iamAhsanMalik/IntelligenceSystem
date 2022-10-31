using IFC.Application.DTOs.Location;

namespace IFC.Application.Contracts.Persistence.Repositries;

public interface ILocationRepo
{
    Task CreateLocationAsync(Location location);
    Task DeleteLocationAsync(long? id);
    Task<List<LocationDTO>> GetLocationsAsync();
    Task<LocationDTO> GetLocationsAsync(long? id);
}