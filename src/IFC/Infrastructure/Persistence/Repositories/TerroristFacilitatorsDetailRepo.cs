using IFC.Application.Contracts.Persistence.Repositries;

namespace IFC.Infrastructure.Persistence.Repositories;

public class TerroristFacilitatorsDetailRepo : ITerroristFacilitatorsDetailRepo
{
    private readonly IFCDbContext _dbContext;
    public TerroristFacilitatorsDetailRepo(IFCDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<TerroristFacilitatorsDetail>> GetTerroristFacilitatorsDetailsAsync()
    {
        var iFCDbContext = await _dbContext.TerroristFacilitatorsDetails.Include(t => t.Address).Include(t => t.RelationType).ToListAsync();

        return iFCDbContext;
    }
    public async Task<TerroristFacilitatorsDetail?> GetTerroristFacilitatorsDetailsAsync(long? id)
    {
        return await _dbContext.TerroristFacilitatorsDetails
            .Include(t => t.Address)
            .Include(t => t.RelationType)
            .FirstOrDefaultAsync(m => m.Id == id);

    }
    public async Task CreateTerroristFacilitatorsDetailAsync(TerroristFacilitatorsDetail terroristFacilitatorsDetail)
    {
        _dbContext.Add(terroristFacilitatorsDetail);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteTerroristFacilitatorsDetailAsync(long? id)
    {
        var TerroristFacilitatorsDetail = await _dbContext.TerroristFacilitatorsDetails.FindAsync(id);
        if (TerroristFacilitatorsDetail != null)
        {
            _dbContext.TerroristFacilitatorsDetails.Remove(TerroristFacilitatorsDetail);
        }
        await _dbContext.SaveChangesAsync();
    }
}
