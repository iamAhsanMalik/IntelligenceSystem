using IFC.Application.DTOs.Incident;

namespace IFC.Application.Contracts.Persistence.Repositries;

public class IncidentRepo : IIncidentRepo
{
    private readonly IFCDbContext _dbContext;
    private readonly IMapper _mapper;

    public IncidentRepo(IFCDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<IncidentDTO>> GetIncidentsAsync()
    {
        var iFCDbContext = _dbContext.Incidents.Include(i => i.Location).Include(i => i.Organization).Include(i => i.SuspectsProfile).Include(i => i.Wing);
        return _mapper.Map<List<IncidentDTO>>(await iFCDbContext.ToListAsync());
    }
    public async Task<IncidentDTO> GetIncidentsAsync(long? id)
    {
        var result = await _dbContext.Incidents
                    .Include(i => i.Location)
                    .Include(i => i.Organization)
                    .Include(i => i.SuspectsProfile)
                    .Include(i => i.Wing)
                    .FirstOrDefaultAsync(m => m.Id == id);
        return _mapper.Map<IncidentDTO>(result!);
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
