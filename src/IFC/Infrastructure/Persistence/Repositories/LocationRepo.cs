namespace IFC.Infrastructure.Persistence.Repositories;

public class LocationRepo : ILocationRepo
{
    private readonly IFCDbContext _dbContext;
    public LocationRepo(IFCDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Location>> GetLocationsAsync()
    {
        return await _dbContext.Locations.ToListAsync();
    }
    public async Task<Location?> GetLocationsAsync(long? id)
    {
        return await _dbContext.Locations.FirstOrDefaultAsync(m => m.Id == id);
    }
    public async Task CreateLocationAsync(Location location)
    {
        _dbContext.Add(location);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteLocationAsync(long? id)
    {
        var location = await _dbContext.Locations.FindAsync(id);
        if (location != null)
        {
            _dbContext.Locations.Remove(location);
        }
        await _dbContext.SaveChangesAsync();
    }
}
