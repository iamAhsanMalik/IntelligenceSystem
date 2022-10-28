using IFC.Application.Contracts.Persistence.Repositries;
using IFC.Application.DTOs.TerroristInvolvement;

namespace IFC.Infrastructure.Persistence.Repositories;

public class TerroristInvolvementRepo : ITerroristInvolvementRepo
{
    private readonly IFCDbContext _dbContext;
    private readonly IMapper _mapper;

    public TerroristInvolvementRepo(IFCDbContext dbContext,IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<TerroristInvolvementDTO>> GetTerroristInvolvementsAsync()
    {
        return _mapper.Map<List<TerroristInvolvementDTO>> (await _dbContext.TerroristInvolvements.ToListAsync());

    }
    public async Task<TerroristInvolvementDTO> GetTerroristInvolvementsAsync(long? id)
    {
      var result= await _dbContext.TerroristInvolvements
            .FirstOrDefaultAsync(m => m.Id == id);
        return _mapper.Map <TerroristInvolvementDTO>(result!);

    }
    public async Task CreateTerroristInvolvementsAsync(TerroristInvolvement TerroristInvolvements)
    {
        _dbContext.Add(TerroristInvolvements);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteTerroristInvolvementsAsync(long? id)
    {
        var TerroristInvolvement = await _dbContext.TerroristInvolvements.FindAsync(id);
        if (TerroristInvolvement != null)
        {
            _dbContext.TerroristInvolvements.Remove(TerroristInvolvement);
        }
        await _dbContext.SaveChangesAsync();
    }
}
