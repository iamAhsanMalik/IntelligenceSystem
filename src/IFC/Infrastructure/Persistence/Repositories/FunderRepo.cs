using IFC.Application.Contracts.Persistence.Repositries;

namespace IFC.Infrastructure.Persistence.Repositories;

public class FunderRepo : IFunderRepo
{
    private readonly IFCDbContext _dbContext;
    public FunderRepo(IFCDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Funder>> GetFundersAsync()
    {
        return await _dbContext.Funders.ToListAsync();
    }
    public async Task<Funder?> GetFundersAsync(long? id)
    {
        return await _dbContext.Funders.FirstOrDefaultAsync(m => m.Id == id);
    }
    public async Task CreateFunderAsync(Funder funder)
    {
        _dbContext.Add(funder);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteFunderAsync(long? id)
    {
        var approval = await _dbContext.Funders.FindAsync(id);
        if (approval != null)
        {
            _dbContext.Funders.Remove(approval);
        }
        await _dbContext.SaveChangesAsync();
    }
}
