using IFC.Application.Contracts.Persistence.Repositries;
using IFC.Application.DTOs.Affiliate;

namespace IFC.Infrastructure.Persistence.Repositories;

public class AffiliateRepo : IAffiliateRepo
{
    private readonly IFCDbContext _dbContext;
    private readonly IMapper _mapper;

    public AffiliateRepo(IFCDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<AffiliateDTO>> GetAffiliatesAsync()
    {
        return _mapper.Map<List<AffiliateDTO>>(await _dbContext.Affiliates.ToListAsync());
    }
    public async Task<AffiliateDTO> GetAffiliatesAsync(long? id)
    {
        var result = await _dbContext.Affiliates.FirstOrDefaultAsync(m => m.Id == id);
        return _mapper.Map<AffiliateDTO>(result!);
    }
    public async Task CreateAffiliatesAsync(Affiliate affiliate)
    {
        _dbContext.Add(affiliate);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteAffiliatesAsync(long? id)
    {
        var affiliate = await _dbContext.Affiliates.FindAsync(id);
        if (affiliate != null)
        {
            _dbContext.Affiliates.Remove(affiliate);
        }

        await _dbContext.SaveChangesAsync();
    }

}