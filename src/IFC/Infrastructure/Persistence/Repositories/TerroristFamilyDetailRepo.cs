using IFC.Application.Contracts.Persistence.Repositries;

namespace IFC.Infrastructure.Persistence.Repositories;

public class TerroristFamilyDetailRepo : ITerroristFamilyDetailRepo
{
    private readonly IFCDbContext _dbContext;
    public TerroristFamilyDetailRepo(IFCDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<TerroristFamilyDetail>> GetTerroristFamilyDetailReposAsync()
    {
        var iFCDbContext = await _dbContext.TerroristFamilyDetails.Include(t => t.Address).Include(t => t.RelationType).ToListAsync();

        return iFCDbContext;
    }
    public async Task<TerroristFamilyDetail?> GetTerroristFamilyDetailReposAsync(long? id)
    {
        return await _dbContext.TerroristFamilyDetails
            .Include(t => t.Address)
            .Include(t => t.RelationType)
            .FirstOrDefaultAsync(m => m.Id == id);

    }
    public async Task CreateTerroristFamilyDetailAsync(TerroristFamilyDetail terroristFamilyDetail)
    {
        _dbContext.Add(terroristFamilyDetail);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteTerroristFamilyDetailReposAsync(long? id)
    {
        var TerroristFamilyDetail = await _dbContext.TerroristFamilyDetails.FindAsync(id);
        if (TerroristFamilyDetail != null)
        {
            _dbContext.TerroristFamilyDetails.Remove(TerroristFamilyDetail);
        }
        await _dbContext.SaveChangesAsync();
    }
}
