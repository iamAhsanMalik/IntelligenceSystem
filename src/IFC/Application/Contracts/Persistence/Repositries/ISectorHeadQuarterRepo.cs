using IFC.Application.DTOs.SectorHeadQuarter;

namespace IFC.Application.Contracts.Persistence.Repositries;

public interface ISectorHeadQuarterRepo
{
    Task CreateSectorHeadQuarterDetailAsync(SectorHeadQuarter socialMediaProfile);
    Task DeleteSectorHeadQuarterDetailReposAsync(long? id);
    Task<List<SectorHeadQuarterDTO>> GetSectorHeadQuarterDetailReposAsync();
    Task<SectorHeadQuarterDTO> GetSectorHeadQuarterDetailReposAsync(long? id);
}