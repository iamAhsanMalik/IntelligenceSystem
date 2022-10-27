namespace IFC.Infrastructure.Persistence.Repositories;

public class OperationalBaseRepo
{
    private readonly IFCDbContext _dbContext;
    public OperationalBaseRepo(IFCDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<OperationalBase>> GetOperationalBaseDetailReposAsync()
    {
        var iFCDbContext = await _dbContext.OperationalBases.ToListAsync();

        return iFCDbContext;
    }
    public async Task<OperationalBase?> GetOperationalBaseDetailReposAsync(long? id)
    {
        return await _dbContext.OperationalBases
            .FirstOrDefaultAsync(m => m.Id == id);

    }
    public async Task CreateOperationalBaseDetailAsync(OperationalBase operationalBase)
    {
        _dbContext.Add(operationalBase);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteOperationalBaseDetailReposAsync(long? id)
    {
        var operationalBase = await _dbContext.OperationalBases.FindAsync(id);
        if (operationalBase != null)
        {
            _dbContext.OperationalBases.Remove(operationalBase);
        }
        await _dbContext.SaveChangesAsync();
    }
}
