using IFC.Application.Contracts.Persistence.Repositries;
using IFC.Application.DTOs.City;

namespace IFC.Infrastructure.Persistence.Repositories;

public class CityRepo : ICityRepo
{
    private readonly IFCDbContext _dbContext;
    private readonly IMapper _mapper;

    public CityRepo(IFCDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<CityDTO>> GetCitiesAsync()
    {
        return _mapper.Map<List<CityDTO>>(await _dbContext.Cities.ToListAsync());
    }
    public async Task<CityDTO> GetCitiesAsync(long? id)
    {
        var result = await _dbContext.Cities
            .FirstOrDefaultAsync(m => m.Id == id);
        return _mapper.Map<CityDTO>(result!);
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