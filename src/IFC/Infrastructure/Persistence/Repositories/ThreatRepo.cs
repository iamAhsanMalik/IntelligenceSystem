
using IFC.Application.Contracts.Persistence.Repositries;
using IFC.Application.DTOs.Threat;

namespace IFC.Infrastructure.Persistence.Repositories;

public class ThreatRepo : IThreatRepo
{
    private readonly IFCDbContext _dbContext;
    private readonly IMapper _mapper;

    public ThreatRepo(IFCDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<ThreatDTO>> GetThreatsAsync()
    {
        return _mapper.Map<List<ThreatDTO>>(await _dbContext.Threats.Include(t => t.Incident).Include(t => t.Location).Include(t => t.Organization).Include(t => t.SuspectsProfile).Include(t => t.Wing).ToListAsync());
    }
    public async Task<ThreatDTO> GetThreatsAsync(long? id)
    {
        var result = await _dbContext.Threats
            .Include(t => t.Incident)
            .Include(t => t.Location)
            .Include(t => t.Organization)
            .Include(t => t.SuspectsProfile)
            .Include(t => t.Wing)
            .FirstOrDefaultAsync(m => m.Id == id);
        return _mapper.Map<ThreatDTO>(result!);
    }
    public async Task CreateThreatAsync(Threat threat)
    {
        _dbContext.Add(threat);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteThreatAsync(long? id)
    {
        var threat = await _dbContext.Threats.FindAsync(id);
        if (threat != null)
        {
            _dbContext.Threats.Remove(threat);
        }
        await _dbContext.SaveChangesAsync();
    }
}
