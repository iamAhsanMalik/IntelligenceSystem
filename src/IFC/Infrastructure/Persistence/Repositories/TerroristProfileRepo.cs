using IFC.Application.Contracts.Persistence.Repositries;

namespace IFC.Infrastructure.Persistence.Repositories;

public class TerroristProfileRepo : ITerroristProfileRepo
{
    private readonly IFCDbContext _dbContext;
    public TerroristProfileRepo(IFCDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<TerroristProfile>> GetTerroristProfilesAsync()
    {
        var iFCDbContext = await _dbContext.TerroristProfiles.Include(t => t.Address).Include(t => t.Orgnization).Include(t => t.TerroristFacilitatorsDetails).Include(t => t.TerroristFamilyDetails).Include(t => t.TerroristInvolvement).ToListAsync();

        return iFCDbContext;
    }
    public async Task<TerroristProfile?> GetTerroristProfilesAsync(long? id)
    {
        return await _dbContext.TerroristProfiles
            .Include(t => t.Address)
            .Include(t => t.Orgnization)
            .Include(t => t.TerroristFacilitatorsDetails)
            .Include(t => t.TerroristFamilyDetails)
            .Include(t => t.TerroristInvolvement)
            .FirstOrDefaultAsync(m => m.Id == id);

    }
    public async Task CreateTerroristProfilesAsync(TerroristProfile TerroristProfiles)
    {
        _dbContext.Add(TerroristProfiles);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteTerroristProfilesAsync(long? id)
    {
        var TerroristProfile = await _dbContext.TerroristProfiles.FindAsync(id);
        if (TerroristProfile != null)
        {
            _dbContext.TerroristProfiles.Remove(TerroristProfile);
        }
        await _dbContext.SaveChangesAsync();
    }
}
