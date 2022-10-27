namespace IFC.Application.Contracts.Persistence.Repositries;

public interface ICityRepo
{
    Task CreateCityAsync(City city);
    Task DeleteCityAsync(long? id);
    Task<List<City>> GetCitiesAsync();
    Task<City?> GetCitiesAsync(long? id);
}