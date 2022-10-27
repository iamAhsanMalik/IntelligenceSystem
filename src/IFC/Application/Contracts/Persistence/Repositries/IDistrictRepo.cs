namespace IFC.Application.Contracts.Persistence.Repositries;

public interface IDistrictRepo
{
    Task CreateDistrictAsync(District district);
    Task DeleteDistrictAsync(long? id);
    Task<List<District>> GetDistrictsAsync();
    Task<District?> GetDistrictsAsync(long? id);
}