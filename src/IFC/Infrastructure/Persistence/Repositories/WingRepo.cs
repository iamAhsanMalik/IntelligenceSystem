using IFC.Application.Contracts.Persistence.Repositries;

namespace IFC.Infrastructure.Persistence.Repositories;

public class WingRepo : IWingRepo
{
    private readonly IFCDbContext _dbContext;
    public WingRepo(IFCDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Wing>> GetWingsAsync()
    {
        var iFCDbContext = await _dbContext.Wings.Include(w => w.CoreHeadQuarter).ToListAsync();

        return iFCDbContext;
    }
    public async Task<Wing?> GetWingsAsync(long? id)
    {
        return await _dbContext.Wings
            .Include(w => w.CoreHeadQuarter)
            .FirstOrDefaultAsync(m => m.Id == id);

    }
    public async Task CreateWingsAsync(Wing wing)
    {
        _dbContext.Add(wing);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteWingsAsync(long? id)
    {
        var wing = await _dbContext.Wings.FindAsync(id);
        if (wing != null)
        {
            _dbContext.Wings.Remove(wing);
        }
        await _dbContext.SaveChangesAsync();
    }
}
