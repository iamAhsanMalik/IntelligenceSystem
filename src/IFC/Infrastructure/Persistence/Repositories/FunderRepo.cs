using IFC.Application.Contracts.Persistence.Repositries;
using IFC.Application.DTOs.Funder;

namespace IFC.Infrastructure.Persistence.Repositories;

public class FunderRepo : IFunderRepo
{
    private readonly IFCDbContext _dbContext;
    private readonly IMapper _mapper;

    public FunderRepo(IFCDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<FunderDTO>> GetFundersAsync()
    {
        return _mapper.Map<List<FunderDTO>>(await _dbContext.Funders.ToListAsync());
    }
    public async Task<FunderDTO> GetFundersAsync(long? id)
    {
        var result = await _dbContext.Funders.FirstOrDefaultAsync(m => m.Id == id);
        return _mapper.Map<FunderDTO>(result!);
    }
    public async Task CreateFunderAsync(Funder funder)
    {
        _dbContext.Add(funder);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteFunderAsync(long? id)
    {
        var approval = await _dbContext.Funders.FindAsync(id);
        if (approval != null)
        {
            _dbContext.Funders.Remove(approval);
        }
        await _dbContext.SaveChangesAsync();
    }
}
