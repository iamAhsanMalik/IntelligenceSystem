using IFC.Application.Contracts.Persistence.Repositries;
using IFC.Application.DTOs.TerroristFacilitatorsDetail;

namespace IFC.Infrastructure.Persistence.Repositories;

public class TerroristFacilitatorsDetailRepo : ITerroristFacilitatorsDetailRepo
{
    private readonly IFCDbContext _dbContext;
    private readonly IMapper _mapper;

    public TerroristFacilitatorsDetailRepo(IFCDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<TerroristFacilitatorsDetailDTO>> GetTerroristFacilitatorsDetailsAsync()
    {
        return _mapper.Map<List<TerroristFacilitatorsDetailDTO>>(await _dbContext.TerroristFacilitatorsDetails.Include(t => t.Address).Include(t => t.RelationType).ToListAsync());


    }
    public async Task<TerroristFacilitatorsDetailDTO> GetTerroristFacilitatorsDetailsAsync(long? id)
    {
        var result = await _dbContext.TerroristFacilitatorsDetails
             .Include(t => t.Address)
             .Include(t => t.RelationType)
             .FirstOrDefaultAsync(m => m.Id == id);
        return _mapper.Map<TerroristFacilitatorsDetailDTO>(result!);

    }
    public async Task CreateTerroristFacilitatorsDetailAsync(TerroristFacilitatorsDetail terroristFacilitatorsDetail)
    {
        _dbContext.Add(terroristFacilitatorsDetail);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteTerroristFacilitatorsDetailAsync(long? id)
    {
        var TerroristFacilitatorsDetail = await _dbContext.TerroristFacilitatorsDetails.FindAsync(id);
        if (TerroristFacilitatorsDetail != null)
        {
            _dbContext.TerroristFacilitatorsDetails.Remove(TerroristFacilitatorsDetail);
        }
        await _dbContext.SaveChangesAsync();
    }
}
