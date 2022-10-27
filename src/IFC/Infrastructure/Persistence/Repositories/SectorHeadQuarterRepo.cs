using IFC.Application.Contracts.Persistence.Repositries;

namespace IFC.Infrastructure.Persistence.Repositories;

public class SectorHeadQuarterRepo : ISectorHeadQuarterRepo
{
    private readonly IFCDbContext _dbContext;
    public SectorHeadQuarterRepo(IFCDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<SectorHeadQuarter>> GetSectorHeadQuarterDetailReposAsync()
    {
        var iFCDbContext = await _dbContext.SectorHeadQuarters.ToListAsync();

        return iFCDbContext;
    }
    public async Task<SectorHeadQuarter?> GetSectorHeadQuarterDetailReposAsync(long? id)
    {
        return await _dbContext.SectorHeadQuarters
            .FirstOrDefaultAsync(m => m.Id == id);

    }
    public async Task CreateSectorHeadQuarterDetailAsync(SectorHeadQuarter socialMediaProfile)
    {
        _dbContext.Add(socialMediaProfile);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteSectorHeadQuarterDetailReposAsync(long? id)
    {
        var socialMediaProfile = await _dbContext.SectorHeadQuarters.FindAsync(id);
        if (socialMediaProfile != null)
        {
            _dbContext.SectorHeadQuarters.Remove(socialMediaProfile);
        }
        await _dbContext.SaveChangesAsync();
    }
}
