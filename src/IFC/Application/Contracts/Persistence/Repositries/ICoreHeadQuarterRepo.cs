using IFC.Application.DTOs.CoreHeadQuarter;

namespace IFC.Application.Contracts.Persistence.Repositries;

public interface ICoreHeadQuarterRepo
{
    Task CreateCoreHeadQuarterAsync(CoreHeadQuarter coreHeadQuarter);
    Task DeleteCoreHeadQuarterAsync(long? id);
    Task<List<CoreHeadQuarterDTO>> GetCoreHeadQuartersAsync();
    Task<CoreHeadQuarterDTO> GetCoreHeadQuartersAsync(long? id);
}