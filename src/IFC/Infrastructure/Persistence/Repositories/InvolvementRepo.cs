using IFC.Application.Contracts.Persistence.Repositries;
using IFC.Application.DTOs.Involvement;

namespace IFC.Infrastructure.Persistence.Repositories;

public class InvolvementRepo : IInvolvementRepo
{
    private readonly IFCDbContext _dbContext;
    private readonly IMapper _mapper;

    public InvolvementRepo(IFCDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<InvolvementDTO>> GetInvolvementsAsync()
    {
        return _mapper.Map<List<InvolvementDTO>>(await _dbContext.Involvements.ToListAsync());
    }
    public async Task<InvolvementDTO> GetInvolvementsAsync(long? id)
    {
        var result = await _dbContext.Involvements.FirstOrDefaultAsync(m => m.Id == id);
        return _mapper.Map<InvolvementDTO>(result!);
    }
    public async Task CreateInvolvementAsync(Involvement involvement)
    {
        _dbContext.Add(involvement);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteInvolvementAsync(long? id)
    {
        var involvement = await _dbContext.Involvements.FindAsync(id);
        if (involvement != null)
        {
            _dbContext.Involvements.Remove(involvement);
        }
        await _dbContext.SaveChangesAsync();
    }

}
