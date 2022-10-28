using IFC.Application.Contracts.Persistence.Repositries;
using IFC.Application.DTOs.OperationalBase;

namespace IFC.Infrastructure.Persistence.Repositories;

public class OperationalBaseRepo : IOperationalBaseRepo
{
    private readonly IFCDbContext _dbContext;
    private readonly IMapper _mapper;

    public OperationalBaseRepo(IFCDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<OperationalBaseDTO>> GetOperationalBaseDetailReposAsync()
    {
        return _mapper.Map<List<OperationalBaseDTO>>(await _dbContext.OperationalBases.ToListAsync());
    }
    public async Task<OperationalBaseDTO> GetOperationalBaseDetailReposAsync(long? id)
    {
        var result = await _dbContext.OperationalBases
            .FirstOrDefaultAsync(m => m.Id == id);
        return _mapper.Map<OperationalBaseDTO>(result!);

    }
    public async Task CreateOperationalBaseDetailAsync(OperationalBase operationalBase)
    {
        _dbContext.Add(operationalBase);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteOperationalBaseDetailReposAsync(long? id)
    {
        var operationalBase = await _dbContext.OperationalBases.FindAsync(id);
        if (operationalBase != null)
        {
            _dbContext.OperationalBases.Remove(operationalBase);
        }
        await _dbContext.SaveChangesAsync();
    }
}
