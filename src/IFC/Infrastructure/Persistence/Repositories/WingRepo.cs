using IFC.Application.Contracts.Persistence.Repositries;
using IFC.Application.DTOs.Wing;

namespace IFC.Infrastructure.Persistence.Repositories;

public class WingRepo : IWingRepo
{
    private readonly IFCDbContext _dbContext;
    private readonly IMapper _mapper;

    public WingRepo(IFCDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<WingDTO>> GetWingsAsync()
    {
        return _mapper.Map<List<WingDTO>>(await _dbContext.Wings.Include(w => w.CoreHeadQuarter).ToListAsync());
    }
    public async Task<WingDTO> GetWingsAsync(long? id)
    {
        var result = await _dbContext.Wings
            .Include(w => w.CoreHeadQuarter)
            .FirstOrDefaultAsync(m => m.Id == id);
        return _mapper.Map<WingDTO>(result!);

    }
    public async Task CreateWingsAsync(Wing wing)
    {
        _dbContext.Add(wing);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteWingsAsync(long? id)
    {
        var wing = await _dbContext.Wings.FindAsync(id);
        if (wing != null)
        {
            _dbContext.Wings.Remove(wing);
        }
        await _dbContext.SaveChangesAsync();
    }
}
