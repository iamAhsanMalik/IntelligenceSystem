namespace IFC.Infrastructure.Persistence.Repositories;

public class InvolvementRepo : IInvolvementRepo
{
    private readonly IFCDbContext _dbContext;
    public InvolvementRepo(IFCDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Involvement>> GetInvolvementsAsync()
    {
        return await _dbContext.Involvements.ToListAsync();
    }
    public async Task<Involvement?> GetInvolvementsAsync(long? id)
    {
        return await _dbContext.Involvements.FirstOrDefaultAsync(m => m.Id == id);
    }
    public async Task CreateInvolvementAsync(Involvement involvement)
    {
        _dbContext.Add(involvement);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteInvolvementAsync(long? id)
    {
        var involvement = await _dbContext.Involvements.FindAsync(id);
        if (involvement != null)
        {
            _dbContext.Involvements.Remove(involvement);
        }
        await _dbContext.SaveChangesAsync();
    }

}
