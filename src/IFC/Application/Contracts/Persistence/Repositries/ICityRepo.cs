using IFC.Application.DTOs.City;

namespace IFC.Application.Contracts.Persistence.Repositries;

public interface ICityRepo
{
    Task CreateCityAsync(City city);
    Task DeleteCityAsync(long? id);
    Task<List<CityDTO>> GetCitiesAsync();
    Task<CityDTO> GetCitiesAsync(long? id);
}