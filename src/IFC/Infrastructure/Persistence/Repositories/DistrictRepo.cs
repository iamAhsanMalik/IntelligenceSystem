using IFC.Application.Contracts.Persistence.Repositries;
using IFC.Application.DTOs.District;

namespace IFC.Infrastructure.Persistence.Repositories;

public class DistrictRepo : IDistrictRepo
{
    private readonly IFCDbContext _dbContext;
    private readonly IMapper _mapper;

    public DistrictRepo(IFCDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<DistrictDTO>> GetDistrictsAsync()
    {
        return _mapper.Map<List<DistrictDTO>>(await _dbContext.Districts.ToListAsync());
    }
    public async Task<DistrictDTO> GetDistrictsAsync(long? id)
    {
        var result = await _dbContext.Districts.FirstOrDefaultAsync(m => m.Id == id);
        return _mapper.Map<DistrictDTO>(result!);
    }
    public async Task CreateDistrictAsync(District district)
    {
        _dbContext.Add(district);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteDistrictAsync(long? id)
    {
        var district = await _dbContext.Districts.FindAsync(id);
        if (district != null)
        {
            _dbContext.Districts.Remove(district);
        }

        await _dbContext.SaveChangesAsync();
    }
}
