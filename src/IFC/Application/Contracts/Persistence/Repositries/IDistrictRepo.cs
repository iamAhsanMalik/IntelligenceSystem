using IFC.Application.DTOs.District;

namespace IFC.Application.Contracts.Persistence.Repositries;

public interface IDistrictRepo
{
    Task CreateDistrictAsync(District district);
    Task DeleteDistrictAsync(long? id);
    Task<List<DistrictDTO>> GetDistrictsAsync();
    Task<DistrictDTO> GetDistrictsAsync(long? id);
}