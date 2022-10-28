using IFC.Application.DTOs.SectorHeadQuarter;

namespace IFC.Application.Contracts.Persistence.Repositries;

public interface ISectorHeadQuarterRepo
{
    Task CreateSectorHeadQuarterDetailAsync(SectorHeadQuarter socialMediaProfile);
    Task DeleteSectorHeadQuarterDetailAsync(long? id);
    Task<List<SectorHeadQuarterDTO>> GetSectorHeadQuarterDetailsAsync();
    Task<SectorHeadQuarterDTO> GetSectorHeadQuarterDetailsAsync(long? id);
}