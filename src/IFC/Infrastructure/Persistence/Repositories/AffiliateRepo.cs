using IFC.Application.Contracts.Persistence.Repositries;

namespace IFC.Infrastructure.Persistence.Repositories;

public class AffiliateRepo : IAffiliateRepo
{
    private readonly IFCDbContext _dbContext;
    public AffiliateRepo(IFCDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Affiliate>> GetAffiliatesAsync()
    {
        return await _dbContext.Affiliates.ToListAsync();
    }
    public async Task<Affiliate?> GetAffiliatesAsync(long? id)
    {
        return await _dbContext.Affiliates
            .FirstOrDefaultAsync(m => m.Id == id);
    }
    public async Task CreateAffiliatesAsync(Affiliate affiliate)
    {
        _dbContext.Add(affiliate);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteAffiliatesAsync(long? id)
    {
        var affiliate = await _dbContext.Affiliates.FindAsync(id);
        if (affiliate != null)
        {
            _dbContext.Affiliates.Remove(affiliate);
        }

        await _dbContext.SaveChangesAsync();
    }

}