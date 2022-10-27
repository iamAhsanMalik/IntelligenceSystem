namespace IFC.Infrastructure.Persistence.Repositories;

public interface ICoreHeadQuarterRepo
{
    Task CreateCoreHeadQuarterAsync(CoreHeadQuarter coreHeadQuarter);
    Task DeleteCoreHeadQuarterAsync(long? id);
    Task<List<CoreHeadQuarter>> GetCoreHeadQuartersAsync();
    Task<CoreHeadQuarter?> GetCoreHeadQuartersAsync(long? id);
}