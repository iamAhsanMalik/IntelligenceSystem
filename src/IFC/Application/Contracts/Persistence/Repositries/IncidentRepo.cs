namespace IFC.Application.Contracts.Persistence.Repositries;

public class IncidentRepo : IIncidentRepo
{
    private readonly IFCDbContext _dbContext;
    public IncidentRepo(IFCDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Incident>> GetIncidentsAsync()
    {
        var iFCDbContext = _dbContext.Incidents.Include(i => i.Location).Include(i => i.Organization).Include(i => i.SuspectsProfile).Include(i => i.Wing);
        return await iFCDbContext.ToListAsync();
    }
    public async Task<Incident?> GetIncidentsAsync(long? id)
    {
        return await _dbContext.Incidents
            .Include(i => i.Location)
            .Include(i => i.Organization)
            .Include(i => i.SuspectsProfile)
            .Include(i => i.Wing)
            .FirstOrDefaultAsync(m => m.Id == id);
    }
    public async Task CreateIncidentAsync(Incident incident)
    {
        _dbContext.Add(incident);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteIncidentAsync(long? id)
    {
        var incident = await _dbContext.Incidents.FindAsync(id);
        if (incident != null)
        {
            _dbContext.Incidents.Remove(incident);
        }
        await _dbContext.SaveChangesAsync();
    }
}
