using IFC.Application.Contracts.Persistence.Repositries;
using IFC.Application.DTOs.SectorHeadQuarter;

namespace IFC.Infrastructure.Persistence.Repositories;

public class SectorHeadQuarterRepo : ISectorHeadQuarterRepo
{
    private readonly IFCDbContext _dbContext;
    private readonly IMapper _mapper;

    public SectorHeadQuarterRepo(IFCDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<SectorHeadQuarterDTO>> GetSectorHeadQuarterDetailsAsync()
    {
        return _mapper.Map<List<SectorHeadQuarterDTO>>(await _dbContext.SectorHeadQuarters.ToListAsync());
    }
    public async Task<SectorHeadQuarterDTO> GetSectorHeadQuarterDetailsAsync(long? id)
    {
        var result = await _dbContext.SectorHeadQuarters
            .FirstOrDefaultAsync(m => m.Id == id);
        return _mapper.Map<SectorHeadQuarterDTO>(result!);
    }
    public async Task CreateSectorHeadQuarterDetailAsync(SectorHeadQuarter socialMediaProfile)
    {
        _dbContext.Add(socialMediaProfile);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteSectorHeadQuarterDetailAsync(long? id)
    {
        var socialMediaProfile = await _dbContext.SectorHeadQuarters.FindAsync(id);
        if (socialMediaProfile != null)
        {
            _dbContext.SectorHeadQuarters.Remove(socialMediaProfile);
        }
        await _dbContext.SaveChangesAsync();
    }
}
