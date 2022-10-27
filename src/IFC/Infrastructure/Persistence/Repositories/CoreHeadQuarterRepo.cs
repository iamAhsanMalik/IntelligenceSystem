namespace IFC.Infrastructure.Persistence.Repositories;

public class CoreHeadQuarterRepo : ICoreHeadQuarterRepo
{
    private readonly IFCDbContext _dbContext;
    public CoreHeadQuarterRepo(IFCDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<CoreHeadQuarter>> GetCoreHeadQuartersAsync()
    {
        var iFCDbContext = _dbContext.CoreHeadQuarters.Include(c => c.SectorHeadQuarter);
        return await iFCDbContext.ToListAsync();
    }
    public async Task<CoreHeadQuarter?> GetCoreHeadQuartersAsync(long? id)
    {
        return await _dbContext.CoreHeadQuarters
            .Include(c => c.SectorHeadQuarter)
            .FirstOrDefaultAsync(m => m.Id == id);
    }
    public async Task CreateCoreHeadQuarterAsync(CoreHeadQuarter coreHeadQuarter)
    {
        _dbContext.Add(coreHeadQuarter);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteCoreHeadQuarterAsync(long? id)
    {
        var coreHeadQuarter = await _dbContext.CoreHeadQuarters.FindAsync(id);
        if (coreHeadQuarter != null)
        {
            _dbContext.CoreHeadQuarters.Remove(coreHeadQuarter);
        }

        await _dbContext.SaveChangesAsync();
    }
}
