using IFC.Application.Contracts.Persistence.Repositries;
using IFC.Application.DTOs.TerroristFamilyDetail;

namespace IFC.Infrastructure.Persistence.Repositories;

public class TerroristFamilyDetailRepo : ITerroristFamilyDetailRepo
{
    private readonly IFCDbContext _dbContext;
    private readonly IMapper _mapper;

    public TerroristFamilyDetailRepo(IFCDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<TerroristFamilyDetailDTO>> GetTerroristFamilyDetailReposAsync()
    {
        return _mapper.Map < List < TerroristFamilyDetailDTO >> (await _dbContext.TerroristFamilyDetails.Include(t => t.Address).Include(t => t.RelationType).ToListAsync());

        
    }
    public async Task<TerroristFamilyDetailDTO> GetTerroristFamilyDetailReposAsync(long? id)
    {
        var result= await _dbContext.TerroristFamilyDetails
            .Include(t => t.Address)
            .Include(t => t.RelationType)
            .FirstOrDefaultAsync(m => m.Id == id);
        return _mapper.Map<TerroristFamilyDetailDTO>(result!);

    }
    public async Task CreateTerroristFamilyDetailAsync(TerroristFamilyDetail terroristFamilyDetail)
    {
        _dbContext.Add(terroristFamilyDetail);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteTerroristFamilyDetailReposAsync(long? id)
    {
        var TerroristFamilyDetail = await _dbContext.TerroristFamilyDetails.FindAsync(id);
        if (TerroristFamilyDetail != null)
        {
            _dbContext.TerroristFamilyDetails.Remove(TerroristFamilyDetail);
        }
        await _dbContext.SaveChangesAsync();
    }
}
