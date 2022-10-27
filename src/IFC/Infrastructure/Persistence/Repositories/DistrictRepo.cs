using IFC.Application.Contracts.Persistence.Repositries;

namespace IFC.Infrastructure.Persistence.Repositories;

public class DistrictRepo : IDistrictRepo
{
    private readonly IFCDbContext _dbContext;
    public DistrictRepo(IFCDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<District>> GetDistrictsAsync()
    {
        return await _dbContext.Districts.ToListAsync();
    }
    public async Task<District?> GetDistrictsAsync(long? id)
    {
        return await _dbContext.Districts.FirstOrDefaultAsync(m => m.Id == id);
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
