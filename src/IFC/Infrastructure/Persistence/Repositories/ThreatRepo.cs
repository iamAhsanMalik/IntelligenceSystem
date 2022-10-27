
using IFC.Application.Contracts.Persistence.Repositries;

namespace IFC.Infrastructure.Persistence.Repositories;

public class ThreatRepo : IThreatRepo
{
    private readonly IFCDbContext _dbContext;
    public ThreatRepo(IFCDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Threat>> GetThreatsAsync()
    {
        var iFCDbContext = await _dbContext.Threats.Include(t => t.Incident).Include(t => t.Location).Include(t => t.Organization).Include(t => t.SuspectsProfile).Include(t => t.Wing).ToListAsync();

        return iFCDbContext;
    }
    public async Task<Threat?> GetThreatsAsync(long? id)
    {
        return await _dbContext.Threats
            .Include(t => t.Incident)
            .Include(t => t.Location)
            .Include(t => t.Organization)
            .Include(t => t.SuspectsProfile)
            .Include(t => t.Wing)
            .FirstOrDefaultAsync(m => m.Id == id);
    }
    public async Task CreateThreatsAsync(Threat threat)
    {
        _dbContext.Add(threat);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteThreatsAsync(long? id)
    {
        var threat = await _dbContext.Threats.FindAsync(id);
        if (threat != null)
        {
            _dbContext.Threats.Remove(threat);
        }
        await _dbContext.SaveChangesAsync();
    }
}
