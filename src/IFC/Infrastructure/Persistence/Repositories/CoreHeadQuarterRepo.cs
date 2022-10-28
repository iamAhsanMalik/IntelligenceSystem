using IFC.Application.Contracts.Persistence.Repositries;
using IFC.Application.DTOs.CoreHeadQuarter;

namespace IFC.Infrastructure.Persistence.Repositories;

public class CoreHeadQuarterRepo : ICoreHeadQuarterRepo
{
    private readonly IFCDbContext _dbContext;
    private readonly IMapper _mapper;

    public CoreHeadQuarterRepo(IFCDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<CoreHeadQuarterDTO>> GetCoreHeadQuartersAsync()
    {
        var iFCDbContext = _dbContext.CoreHeadQuarters.Include(c => c.SectorHeadQuarter);
        return _mapper.Map<List<CoreHeadQuarterDTO>>(await iFCDbContext.ToListAsync());
    }
    public async Task<CoreHeadQuarterDTO> GetCoreHeadQuartersAsync(long? id)
    {
        var result = await _dbContext.CoreHeadQuarters
            .Include(c => c.SectorHeadQuarter)
            .FirstOrDefaultAsync(m => m.Id == id);
        return _mapper.Map<CoreHeadQuarterDTO>(result!);
    }
    public async Task CreateCoreHeadQuarterAsync(CoreHeadQuarter coreHeadQuarter)
    {
        _dbContext.Add(coreHeadQuarter);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteCoreHeadQuarterAsync(long? id)
    {
        var coreHeadQuarter = await _dbContext.CoreHeadQuarters.FindAsync(id);
        if (coreHeadQuarter != null)
        {
            _dbContext.CoreHeadQuarters.Remove(coreHeadQuarter);
        }

        await _dbContext.SaveChangesAsync();
    }
}
