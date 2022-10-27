using IFC.Application.Contracts.Persistence.Repositries;

namespace IFC.Infrastructure.Persistence.Repositories;

public class CityRepo : ICityRepo
{
    private readonly IFCDbContext _dbContext;
    public CityRepo(IFCDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<City>> GetCitiesAsync()
    {
        return await _dbContext.Cities.ToListAsync();
    }
    public async Task<City?> GetCitiesAsync(long? id)
    {
        return await _dbContext.Cities
            .FirstOrDefaultAsync(m => m.Id == id);
    }
    public async Task CreateCityAsync(City city)
    {
        _dbContext.Add(city);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteCityAsync(long? id)
    {
        var city = await _dbContext.Cities.FindAsync(id);
        if (city != null)
        {
            _dbContext.Cities.Remove(city);
        }
        await _dbContext.SaveChangesAsync();
    }
}